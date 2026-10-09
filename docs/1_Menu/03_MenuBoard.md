# 역할
1. 메뉴들을 목록 보관
2. 메뉴 UI 생성 및 값 할당
3. 개별 메뉴의 클릭 이벤트 동작 구현


# 구상 흐름
[현재 준비된 것]
1. MenuItemData
→ 메뉴 하나의 데이터 보관

2. MenuItemControl
→ 메뉴 하나의 UI 표시
→ 클릭 시 MenuClicked 발생


[이제 필요한 것]
1. 여러 MenuItemData를
  하나의 목록으로 보관할 공간
→ List<MenuItemData> Items

2. 목록을 순회하면서
  MenuItemControl을 생성할 로직
→ Items를 foreach로 순회
→ MenuItemData 하나 확인
→ MenuItemControl 하나 생성

3. 생성한 여러 MenuItemControl을
  화면에 추가할 공간
→ FlowLayoutPanel

4. MenuClicked를 받아
  선택된 메뉴를 확인할 로직
→ 각 MenuItemControl의 MenuClicked를 구독
→ 핸들러 구현
→ sender를 통해 클릭된 MenuItemControl을 확인
→ 클릭된 MenuItemControl의 ID 확인
→ Items에서 같은 ID의 MenuItemData를 찾음
→ 찾은 MenuItemData를 상위로 전달

5. 선택된 메뉴를 상위로 전달할 Event
→ 선택된 메뉴로 인해 직접적으로 영향을 받는 곳은 상위 UI
→ 따라서 선택된 메뉴들의 정보 상위로 전달할 이벤트가 필요
  (설계 기준의 하위의 동작은 Event로 전달한다를 따름)


# 문제 해결
1. 디자인 속성창에서 넣은 Items 내용이 저장안됨.
- 원인: 디자인 속성창에서 넣은 Items 내용을 디자이너가 코드가 저장 못하는 것이다.
→ [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] 작성
→ 의미: Items라는 List 자체만 보지 말고 그 안에 추가한 MenuItemData 내용까지 디자인 코드에 저장해라

2. Items는 저장됐는데 메뉴 UI가 안 만들어짐
- MenuBoard가 생성되는 시점에 생성해내면 될 거라고 생각해서 생성자에 작성했으나 작동하지 않음
- 원인: CreateMenuItems() 실행 시점이 너무 빠름
→ form1의 생성자에서 호출해준다.
→ 런타임 시 동작 과정은 아래와 같다.

[런타임 시 동작 과정]
Form1 생성자 시작
→ InitializeComponent()
   → 아래의 동작이 순차적으로 실행됨
   → 1. 하위 컨트롤 생성
   → 2. 하위 생성자 실행
   → 3. form에 배치된 컨트롤들의 디자인 속성 설정
→ InitializeComponent() 종료
→ 다음 코드 실행
→ Form1 생성자 종료

[MenuBoard의 생성자에 CreateMenuItems()를 넣으면 안되는 이유]
따라서  MenuBoard의 생성자에 
MenuItemControl을 생성하는 CreateMenuItems()를 넣으면,

Form에서 설정한 Items의 디자인 속성값이
적용되기 전에 실행되어 Items가 비어 있기 때문에
메뉴 UI가 생성되지 않는다.



# 주의점
[디자인타임]
→ 실행할 구조와 코드를 준비

- MenuBoard의 UI 구조를 만든다.
- FlowLayoutPanel을 배치한다.
- 메뉴 생성 로직을 코드로 작성해둔다.

[런타임]
→ 준비된 코드가 실행

- 프로그램이 실행된다.
- MenuBoard 객체가 생성된다.
- 메뉴 생성 메서드가 실행된다.
- Items를 순회한다.
- MenuItemControl이 생성된다.
- 각 메뉴 데이터가 적용된다.
- FlowLayoutPanel에 추가된다.
- 사용자가 클릭하는 메뉴의 정보가 상위로 전달된다.