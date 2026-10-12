# 1. 역할
- 메뉴 하나를 화면에 표시하는 UserControl을 만든다.
- 메뉴 하나의 UI만 담당한다.
- 다른 메뉴나 상위 화면의 동작은 직접 처리하지 않는다.
- IMenuItemControl 규격을 구현한다


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

4. 인터페이스 규격 구현
- ID, Title, Price, Image 및 MenuClicked를 공통 규격으로 제공한다.
- 실제 값과 UI 표시는 MenuItemControl이 담당한다.


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

④ 내부 클릭을 대표 이벤트로 전달하는 구조
- 내부 자식 컨트롤들을 재귀적으로 탐색하여
 각 Click 이벤트 핸들러를 공통 핸들러에 연결한다.
 → 공통된 핸들러에서는 
    MenuItemControl의 대표 이벤트인
    MenuClicked를 invoke시킨다.

[전달하는 쪽의 this,this 의미]
먼저 이벤트 선언부를 봐야한다.
public event EventHandler<IMenuItemControl>? MenuClicked;
→ 즉, 해당 이벤트를 통해 IMenuItemControl 타입의 객체를 보내겠다는 의미이다.

첫 번째 this → sender (Object Type)
두 번째 this → e (IMenuItemControl Type)

- 두 인자는 같은 실제 MenuItemControl 객체를 
 Object Type, IMenuItemControl Type으로 전달한다.


[전달받는 쪽의 this,this 의미]
먼저 이벤트 핸들러를 본다.
(IMenuItemControl의 수신 인자 타입이 있어야 한다.)
private void MenuItem_MenuClicked(object? sender, IMenuItemControl e)
{
    int id = e.ID;
    ....
}
- sender와 e는 같은 객체를 뜻하지만 변수의 선언 타입이 다르다.
- sender는 object 타입이므로 ID에 곧바로 접근할 수 없다.
- e는 IMenuItemControl 타입이므로 
  실제 인터페이스에 선언된 속성에 직접 접근할 수 있다.
  (ID, Title, Price 등)
- 실제 값은 MenuItemControl 객체가 보관하고 있다.

[정리]
- 이벤트는 같은 실제 객체를
  object와 IMenuItemControl 타입의
  매개변수로 각각 전달한다.
- 받는 쪽에서는 공통 규격의 멤버에 접근한다.
- 따라서 클릭 처리 코드는
  IMenuItemControl에 의존한다.


첫 번째 sender는 object 타입으로 어떤 객체든 받을 수 있지만
두 번째 e로 IMenuItemControl 타입으로 했기 때문에
IMenuItemControl를 구현한 객체만
핸들러 사용이 가능하게끔 되었고,
e.속성을 사용할 수 있다.

즉, 이 핸들러를 부른 객체가 어떤 구체 클래스인지 구분 짓지 않고,
인터페이스를 구현한 객체라는 사실을 통해 바로 접근할 수 있다.


⑤ 전체 흐름
MenuItemControl 생성
→ AddClickEvent(this)
→ 내부 자식 Click 연결
→ 사용자 클릭
→ Control_Click()
→ MenuClicked?.Invoke(this, this)
→ MenuBoard에서 인터페이스 타입 수신


# 5. 구현 중 의문점 정리
① 메뉴을 생성해내는 것은 MenuItemControl의 책임이 맞을까?
- 메뉴 하나의 UI를 담당하는 것이 목적이므로 적절하지 않다.

② MenuItemControl가 상품 목록, UI 생성 로직을 담당할 수 있을까?
- 아래처럼 구현하면 가능하긴 함. 그러나 부적절하다.
- MenuItemControl 자체에서 메뉴 목록을 지니고,
  목록을 기준으로 new MenuItemControl()을 사용해 
 여러 메뉴 UI를 만든 뒤 상위로 ui를 통채로 주는 형식

③ 인터페이스에 값이 저장될까?
- 아니다. 인터페이스는 규격이다.
- 인터페이스 타입의 참조를 통해
  실제 MenuItemControl 값을 읽지만 
  인터페이스 타입으로 받으면 인터페이스에 정의된 기능만 사용가능하다.

# 6. 최종 정리
1. MenuItemData
→ 메뉴 하나의 실제 정보를 가지므로 어떤 메뉴인지 담당한다.

2. MenuItemControl
→ MenuItemData에서 전달받은 값을 자신의 내부 UI에 어떻게 보여줄지 표시하는 역할을 담당한다.
→ 규격을 구현하고 실제 UI를 표시한다.
→ 클릭 시 자신의 객체를 전달한다.


[데이터 표시 흐름]
MenuItemData
→ 메뉴 데이터 보관
→ MenuItemControl에 전달
→ 내부 속성에 값 적용
→ Label / PictureBox에 표시


# 7. 상위(MenuBoard)에서 담당할 것
- 여러 MenuItemData를 보관한다.
- 메뉴 UI를 생성하고 값을 할당한다.
- MenuClicked를 구독한다.
- 인터페이스 타입으로 클릭 값을 받는다.
- ID에 해당하는 데이터를 찾아
  상위 Form1에 전달한다.

