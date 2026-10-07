# 1. 역할
- 메뉴 하나를 화면에 표시하는 UserControl을 만든다.
- 메뉴 하나의 UI만 담당한다.
- 다른 메뉴나 상위 화면의 동작은 직접 처리하지 않는다.


# 2. 설계 기준
1. 하나의 메뉴만 담당
- MenuItemControl은 메뉴 하나의 UI를 담당한다.

2. 내부 UI 변경은 직접 담당
- 외부에서는 속성을 통해 필요한 값을 전달한다.
- 내부 UI에서는 전달받은 값을 반영한다.
  → 다른 UI가 내부 컨트롤을 직접 수정하지 못하게 한다.


3. 동작 전달은 Event 사용
- 메뉴 선택과 같은 동작은 Event를 통해 외부에 알린다
 → 왜? 메뉴가 사용자에게 선택을 받는다 해도 이 UI에는 영향이 없음
   따라서 이 동작으로 영향을 받는 UI에서 핸들러를 구현하며 동작 정의.


# 3. 구상 흐름
- 메뉴마다 UserControl을 하나씩 직접 만드는 것이 아니라
  메뉴 데이터를 목록에 보관해두고,
  하나씩 꺼내서 MenuItemControl을 생성하는 구조를 구상했다.

- 먼저 메뉴 하나의 공통적인 UI 형태가 어떤지 정의해야한다.
- 모든 메뉴는 UI 동작 형태는 같을 것이기 때문 

[예시]
아메리카노
→ 같은 MenuItemControl 구조
→ Title, Price, Image만 다름

카페라떼
→ 같은 MenuItemControl 구조
→ Title, Price, Image만 다름


# 4. 구현 정리
[1. MenuItemControl의 역할 정리]
- 메뉴 목록에서 메뉴 데이터를 전달받아 넣을 공간 정의
- 자신이 눌러짐을 알리는 이벤트

[2. 실제 구현 로직]
① 커스텀 이벤트 선언
- 이벤트명: MenuClicked 
- 사용: 대표 이벤트

② 아이디, 상품명, 상품가격, 이미지 속성으로 정의
- ID, Title, Price, Image

③ 상품 가격 원본과 화면 표시용 구분
- 원본은 백킹필드에 decimal로 보관
- 화면 표시용 값은 메서드를 통해 문자열로 변환 및 포멧팅 

④ 내부 클릭 시 일관된 하나의 이벤트를 발생시키는 메서드 구현
- 내부 컨트롤들의 Click 이벤트의 핸들러를 공통된 메서드로 연결한다.
  → 공통된 메서드에서는 MenuItemControl의 대표 이벤트인
     MenuClicked를 invoke시킨다.
  → MenuClicked의 invoke 전달 값은 
    첫번째는 this로 이벤트를 발생시킨 자신 UI를 넘긴다.
    두번째는 EventArgs.Empty로 추가적인 전달 값은 없다는 의미다.

- 어떤 MenuItemControl이 클릭됐는지 알 수 있게 해주는 값으로 
 UI자체를 넘긴 것이다.
- 이 동작은 자식 컨트롤이 또 자식을 가지면 재귀적으로 반복한다.

⑤ 전체 흐름
MenuItemControl 생성
→ AddClickEvent(this)
→ 내부 컨트롤 Click 연결
→ 사용자 클릭
→ Control_Click()
→ MenuClicked.Invoke(this,EventArgs.Empty)
→ 상위 UI에서 이벤트 수신


# 5. 구현 중 의문점 정리
① 메뉴을 생성해내는 것은 MenuItemControl의 책임이 맞을까?
- 메뉴 하나의 UI를 담당하는 것이 목적이므로 적절하지 않다.

② MenuItemControl가 상품 목록, UI 생성 로직을 담당할 수 있을까?
- 아래처럼 구현하면 가능하긴 함. 그러나 부적절하다.
- MenuItemControl 자체에서 메뉴 목록을 지니고,
  목록을 기준으로 new MenuItemControl()을 사용해 
 여러 메뉴 UI를 만든 뒤 상위로 ui를 통채로 주는 형식


# 6. 최종 정리
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


# 7. 상위(MenuBoard)에서 담당할 것
- 여러 메뉴 데이터를 보관
- 메뉴 목록을 통한 UI 생성