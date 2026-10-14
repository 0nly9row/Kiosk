# 선행 개념
[구체 타입]
- 실제 객체를 생성할 수 있는 클래스 타입
- 생성된 객체는 실제 값과 동작을 가질 수 있다.

[추상 타입]
- 구현 객체가 제공할 공통의 멤버 규격
- 멤버는 속성, 메서드, 이벤트 등...이 올 수 있다
- 예시로 인터페이스, 추상 클래스가 있다.
- 인터페이스는 new 생성이 불가하다.
- 인터페이스 타입 변수는 구현 객체를 참조할 수 있다.



# 1. 데이터 모델
- 한마디로 "어떤 데이터를 표현할지 생각한다"
- 어떤 대상이나 개념을 데이터로 표현하기 위한 설계 개념
→ 머릿속 생각, 문서, 다이어그램 등으로 표현할 수 있다.

ex) 메뉴는 "ID, Title, Price, Image" 같은 정보를 지닌다고 생각한다.

 
# 2. 데이터 모델 클래스
- 한마디로 "데이터 모델의 생각을 실제 코드로 표현해보자"
- 데이터 모델에서 정한 구조를 실제 클래스로 만든 것이다.

- 실제 객체를 생성할 수 있는 구체 타입이다.
- 생성된 객체는 실제 값을 가질 수 있다.

[ex) MenuItemData 클래스]
public class MenuItemData
{
     public int ID { get; set; }
     public string Title { get; set; } = "";
     public decimal Price { get; set; }
     public Image? Image { get; set; }
 }


MenuItemData data = new MenuItemData(); // 실제 생성된 객체
data.ID = 1;
data.Title = "아메리카노";



# 3. 인터페이스
- 한마디로 "어떤 기능을 갖춰야 하는가?"
- 구현하는 대상이 반드시 제공해야 할 멤버를 규격으로 정의한다.

- 일부 메서드에기본 구현을 제공할 수도 있으나
 현재 프로젝트에서는 실제 값이나 동작을 직접 구현하지 않는다.
- 속성, 메서드, 이벤트 등 갖춰야 할 형태를 정의한다.

[ex) IMenuItemControl]
- 구현한 객체를 IMenuItemControl 타입으로 받아 다룰 수 있다.


public interface IMenuItemControl
{       
     event EventHandler<IMenuItemControl> MenuClicked;
     public int ID { get; set; }
     public string Title { get; set; }
     public decimal Price { get; set; }
     public Image? Image { get; set; }
 }

IMenuItemControl menu  = new IMenuItemControl(); // 객체 생성 불가
IMenuItemControl menu = new MenuItemControl(); // 가능


# 4. 구현 클래스
- 한마디로 "그 기능을 실제로 어떻게 구현할 것인가?"

- 인터페이스에서 정한 규격을 실제 코드로 구현하는 클래스이다.
- 실제 객체를 생성할 수 있는 구체 타입이다.

ex)
public partial class MenuItemControl : UserControl, IMenuItemControl{...실제 구현....}


[인터페이스와 객체의 차이]
- 인터페이스 타입 변수도 실제 객체를 가리킨다.
- 변수에 선언된 인터페이스 멤버를 사용한다.
- 인터페이스 자체에 값이 복사되지는 않는다.

[ex) 인터페이스 타입 변수가 실제 객체의 값을 읽는다]
IMenuItemControl menu = new MenuItemControl();
int id = menu.ID;



# 최종 구분
1. 데이터 모델과 데이터 모델 클래스
[데이터 모델]
→ 어떤 데이터를 표현할지 생각

[데이터 모델 클래스]
→ 그 생각을 실제 코드로 표현


2. 인터페이스와 구현 클래스 
[인터페이스]
→ 어떤 기능을 갖춰야 하는지 정의

[구현 클래스]
→ 그 기능을 실제로 구현



# 현재 키오스크 적용
[1. 데이터 모델 클래스 활용]
- MenuItemData는 메뉴 하나의 데이터를 보관하는 클래스이다.
- MenuBoard는 List<MenuItemData>인 Items를 보관한다.
- Items를 순회하면서 MenuItemControl을 생성하고 데이터를 속성에 할당한다.

MenuItemData
→ MenuBoard.Items에 보관
→ MenuItemControl 생성
→ ID, Title, Price, Image 할당
→ 메뉴 UI 표시


[2. 인터페이스 활용]
- IMenuItemControl은 메뉴 UI의 공통 속성과 이벤트를 정의한다.
- MenuItemControl은 이를 구현한다.
- 클릭 시 자신의 객체를 두 인자로 전달하는 MenuClicked를 발생시킨다.

MenuClicked?.Invoke(this, this);
- 첫 번째 this는 object 타입의 sender,
  두 번째 this는 IMenuItemControl 타입의 e로 전달된다.
- 둘 다 동일한 실제 객체를 참조한다.
- MenuBoard는 e.ID를 직접 읽는다.
- Items에서 같은 ID를 가진 MenuItemData를 찾아 Form1에 전달한다.

MenuItemControl 클릭
→ MenuClicked(this, this)
→ MenuBoard에서 e.ID 확인
→ Items에서 MenuItemData 검색
→ ItemClicked(this, selectedItem)
→ Form1에서 MenuItemData 수신


[3. 적용 효과와 한계]
- 클릭 처리 부분은 MenuItemControl이라는
  구체 클래스 대신 인터페이스를 사용한다.
- 단, MenuBoard의 생성 코드는 
 여전히 new MenuItemControl()을 사용한다.
- 따라서 구체 클래스 의존이 완전히 사라진 것은 아니다.
- Form1에서 장바구니로 전달하는 로직은
  현재 구현 범위 밖이며 추후 연결할 예정이다.


# 한계 계선 방안
1. DI·팩토리 도입
- 현재 MenuBoard는 메뉴 생성 시 MenuItemControl에 직접 의존한다.
- 팩토리나 의존성 주입을 적용하면 객체 생성 책임을 외부로 분리하여 
  MenuBoard의 구체 클래스 의존을 추가로 줄일 수 있다.

- 현재 구조에서는 필수가 아니며 추후 필요할 때 학습하고 적용할 것 이다.