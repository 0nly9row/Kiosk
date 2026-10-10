# [인터페이스 도입에 대한 고뇌.]

# 1. 인터페이스를 전달한다의 의미
- MenuItemControl에서 인터페이스를 구현하고,
 이벤트 invoke 시 (this, this)로 보내면
 1번째 인자: User Control (Object type)
 2번째 인자: User Control (Interface type)

  즉, 실제로 전달되는 것은 둘 다 실제 객체이지만
 받는 변수에 타입에 따라 직접 접근할 수 있는 멤버가 달라진다.

- 그래서 전달받는 쪽에서 
 Object (MenuItemControl)
 Interface (IMenuItemControl) 
 두 타입으로 전달을 받을 수 있다.


# 2. 인터페이스 도입을 고민하는 이유
- 현재 MenuBoard의 클릭 처리 코드를 보면 아래와 같다.
 if (sender is not MenuItemControl menu) return;
  즉, 클릭 객체가 MenuItemControl인지
 구체 클래스 이름으로 검사하고 있다.

- 이러면 다른 종류의 메뉴 카드 UI를 만들면
  이 타입 검사로는 처리되지 않는다.

[가정]
- DrinkMenuControl을 추가한다.
- SideMenuControl도 추가한다.
- 두 컨트롤은 메뉴 클릭 시 같은 방식으로
  메뉴 정보를 제공해야 한다.
- 하지만 MenuItemControl 타입만으로 검사를 하면
 새로운 메뉴 카드가 추가될 때마다 
 구체 클래스에 대한 타입 검사를
 추가하거나 수정해야 할 수 있다.

[고민]
- UI 종류마다 별도의 타입 검사나
  클릭 처리 코드를 작성해야 할까?
- 공통 규격으로 처리할 수 없을까?

[선택]
- IMenuItemControl을 정의한다.
- 각 메뉴 카드가 공통 속성과 이벤트를
  구현하도록 약속한다.
- 클릭을 처리할 때 구체 클래스 대신
  인터페이스 구현 여부를 검사한다.


# 3. 도입 효과와 한계
[효과]
- 클릭 처리 코드가 MenuItemControl이라는
  구체 타입에 직접 의존하지 않게 된다.
- 다른 메뉴 카드도 IMenuItemControl을
  구현하면 같은 클릭 처리 기준을 쓴다.

[한계]
- 현재 메뉴 카드는 한 종류뿐이므로
  당장의 효과는 크지 않을 수 있다.
- MenuBoard의 생성 코드는 여전히
  new MenuItemControl()을 사용한다.
- 즉, 구체 클래스 의존을 완전히
  제거하는 변경은 아니다.
- 카테고리만 다른 메뉴라면 하나의
  MenuItemControl로 처리할 수도 있다.
- 인터페이스만으로 중복 핸들러가
  반드시 생기거나 사라지는 것은 아니다.

[이번 도입의 핵심]
- 메뉴 카드 UI를 전달하지 않는 것이 아니라, 
 클릭 처리 부분의 타입 의존을 줄이고,
 UI를 공통 규격으로 다뤄보는 것이다.
