# 역할
- 메뉴 하나의 정보를 보관하는 Data Model이다.
- 메뉴가 어떤 메뉴인지 표현하기 위한 값만 가진다.
- 화면에 직접 표시하거나 UI 동작을 처리하지 않는다.



# 구상 흐름
- 메뉴마다 UserControl을 하나씩 직접 만드는 것이 아니라
  메뉴 데이터를 목록에 보관해두고,
  하나씩 꺼내서 MenuItemControl을 생성하는 구조를 구상했다.

- 먼저 메뉴 하나의 공통적인 데이터 형태가 어떤지 정의해야한다.
- 모든 메뉴는 데이터 형태는 같고 실제로 들어가는 값만 달라질 것이기 때문이다.

[예시 - '데이터 형태는 같으나 실제 값이 다름']
1. 아메리카노
→ ID = 1
→ Title = "아메리카노"
→ Price = 3000
→ Image = 이미지

2. 카페라떼
→ ID = 2
→ Title = "카페라떼"
→ Price = 3500
→ Image = 이미지

 
# 실제 구현에 필요한 데이터
1. ID
- 메뉴를 목록으로 관리할 때, 어떤 메뉴인지를 구별하기 위한 식별값
2. Title
- 메뉴명 보관
3. Price
- 메뉴 가격 보관
4. Image
- 메뉴 이미지 보관



# MenuItemData를 따로 만드는 이유
- 메뉴 데이터는 UI가 아니라 독립된 데이터여야 하기 때문이다.
→ 메뉴 컨트롤이 없어도 메뉴의 데이터는 존재해야한다

1. 여러 메뉴를 목록으로 관리하려면 컬랙션과 공통된 메뉴 데이터 타입이 필요하다.
- 해당 타입의 객체들을 컬렉션에 넣어 하나의 메뉴 목록으로 관리한다.
[예시]
List<MenuItemData> menuItems
→ 아메리카노
→ 카페라떼
→ 에스프레소


2. 메뉴 데이터를 UI 내부에만 두면 
 UI 객체가 없어질 때 해당 데이터도 함께 사라진다.
- 메뉴 데이터를 MenuItemControl 내부에만 뒀을 때는
 MenuItemControl이 제거되면 메뉴 데이터까지 제거된다.
[예시 - UI제거 시 데이터 삭제로 이어지는 구조]
MenuItemControl ui1 = new MenuItemControl{ui.Price = 3000;};
MenuItemControl ui2 = new MenuItemControl{ui.Price = 4000;};


3. 같은 의미의 메뉴 데이터를 UI와 별도 데이터 객체가
  각각 보관하면 중복 관리가 필요해진다.
① 각각의 객체가 같은 의미의 데이터를 각각 보관하는 경우
- 한 곳의 데이터만 변경이 되었다고 가정하면,
어떤 값이 현재 메뉴 가격의 기준인지 헷갈릴 수 있다.
MenuItemData data = new MenuItemData();
data.Price = 3000;

MenuItemControl ui = new MenuItemControl();
ui.Price = 3000; 

② 한쪽 값을 다른 쪽에 전달하는 경우
- 전달 당시의 값을 전달 받으므로
 전달하는 곳의 값이 변경이 일어나면 자동으로 변하지 않는다
 → data.Price 값이 3500으로 변경이 되면 수동으로 다시 값을 전달해줘야한다
MenuItemData data = new MenuItemData();
data.Price = 3000;

MenuItemControl ui = new MenuItemControl();
ui.Price = data.Price; 


# 최종 정리
1. MenuItemData
→ 메뉴 하나의 실제 정보를 가지므로 어떤 메뉴인지 담당한다.

2. MenuItemControl
→ MenuItemData에서 전달받은 값을 자신의 내부 UI에 어떻게 보여줄지 표시하는 역할을 담당한다.


[흐름]
MenuItemData
→ 메뉴 데이터 보관
→ MenuItemControl에 전달
→ 내부 속성에 값 적용
→ Label / PictureBox에 표시

