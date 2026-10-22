# 선행 개념
[클래스와 객체]
- 클래스는 객체를 만들기 위한 설계도이다.
- 객체는 new로 생성한 실제 대상이다.
- CartItemData는 클래스이다.
- new CartItemData()는 객체를 생성한다.

[참조 타입과 참조 변수]
- class로 만든 CartItemData는 참조 타입이다.
- 참조 타입 변수는 객체를 가리키는
  참조값을 보관한다.
- 참조값은 객체 자체가 아니다.



# 객체 참조
- 한마디로 "변수가 객체를 가리키는 것"이다.
- 같은 객체를 여러 변수가 가리킬 수 있다.
- 참조를 복사해도 객체가 새로 생기지 않는다.

[쉬운 비유]
- 객체는 집, 참조는 집의 주소와 같다.
- 주소를 복사해도 집이 하나 더 생기지 않는다.
- 두 사람이 같은 집을 찾아가는 것이다.

[실제 참조 복사]
CartItemData data = new CartItemData();
data.Title = "아메리카노";

CartItemData other = data;  
other.Title = "카페라테";  .

- data와 other는 같은 객체를 가리킨다.
- 따라서 data.Title도 "카페라테"이다.



# 값 복사와 객체 참조 
[1. 값 타입의 대입]
int a = 1;
int b = a;
b = 2; 

- b에는 a의 숫자 값이 복사된다.
- b를 바꿔도 a는 바뀌지 않는다.
- 결과: a는 1, b는 2이다.


[2. 참조 타입의 대입]
CartItemData a = new CartItemData();
a.Count = 1;
CartItemData b = a;
b.Count = 2;   

- b에는 a의 참조값이 복사된다.
- 두 변수는 같은 객체를 가리킨다.
- b.Count 변경은 그 객체를 변경한다.
- 결과: a.Count도 2이다.

[3. 참조 변수 재대입]
CartItemData a = new CartItemData();
CartItemData b = a;
b = new CartItemData();
b.Count = 3;

- b는 이제 새 객체를 가리킨다.
- a는 처음 객체를 계속 가리킨다.
- b의 재대입으로 a의 참조는 바뀌지 않는다.



# 장바구니 내의 컨트롤들간의 참조
[도식화]
ShoppingCartControl의 
List<CartItemData>_items 항목┐
                             ├→ ShoppingCartControl에서 생성된                                    
 CartItemControl의           │    CartItemData 객체 참조
내부 필드 _data  ──────┘

[설명]
- ShoppingCartControl이 객체를 생성한다.
- _items 목록과 _data 필드가
  같은 CartItemData 객체를 참조한다.
- Data 속성은 _data의 참조를 외부에 보여준다.
- Data에 setter가 없어 외부에서
  참조 대상을 직접 교체할 수 없다.
- 단, Data를 통해 객체 내부 값은 바꿀 수 있다.



# 실제 코드에서의 참조 사용
[1. 장바구니에 처음 담길 때]
- ShoppingCartControl이 CartItemData를 생성한다.
- 생성된 객체를 _items 목록에 담는다.
- CartItemControl의 SetData(data)에 전달한다.
- 이때 내부 필드 _data에도 같은 참조를 저장한다.
- 즉, 목록과 개별 UI가 같은 객체를 참조한다.

[2. 이미 담긴 메뉴를 다시 선택했을 때]
- _items에서 같은 ID의 메뉴를 찾는다.
- 찾은 객체의 Count 속성을 1 증가시킨다.
- 해당 객체를 참조 중인 UI를 찾아야 한다.
- CartItemControl의 Data 속성으로 확인한다.
- 찾은 UI의 RefreshDisplay()를 호출한다.

[3. 장바구니 수량 버튼을 눌렀을 때]
- CartItemControl의 _data로 객체에 접근한다.
- _data.Count++ 또는 Count--로 수량을 바꾼다.
- _items에도 같은 객체가 들어 있으므로
  변경된 수량을 그대로 조회할 수 있다.
- 단, 화면은 자동 변경되지 않으므로
  RefreshDisplay()로 다시 표시한다.

[4. 장바구니 삭제 버튼을 눌렀을 때]
- CartItemControl의 Data로 삭제 대상을 확인한다.
- _items.Remove(control.Data)로
  목록에서 해당 객체의 참조를 제거한다.
- 화면에서도 해당 CartItemControl을 제거한다.
- Dispose()로 사용하지 않는 UI 자원을 정리한다.
- 참조를 제거한다고 객체가 즉시 삭제되지는 않는다.

[5. 전체 취소 메서드를 실행했을 때]
- _items.Clear()로 목록의 참조를 비운다.
- 화면에 올려진 CartItemControl도 제거한다.
- 각 컨트롤은 Dispose()로 정리한다.
- 이후 장바구니 변경 이벤트를 발생시킨다.
- 다른 곳에 참조가 남아 있다면
  객체가 곧바로 사라지는 것은 아니다.
