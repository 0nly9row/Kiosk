# 목차
0. 필요성
1. 역할
2. 설계 기준 
3. 구현 흐름 
4. 실제 구현
5. 현재 구현 상태



# 0. 필요성
- MenuBoard는 어떤 메뉴를 선택했는지 상위 화면에 알려준다.
- 선택한 메뉴를 보관하고 관리할 곳은 없다.
→ 메뉴를 보관하고 관리할 상위 컨트롤이 필요하다



# 1. 역할 
1. 여러 장바구니 항목을 관리하는 UserControl이다.
2. 전달받은 메뉴가 이미 담겨있는 메뉴인지 확인한다.
   → 새 메뉴: 장바구니 항목 추가
   → 같은 메뉴: 기존 수량 증가
3. 항목 삭제 요청을 받아 실제 항목을 제거한다.
4. 전체 수량과 총 금액을 계산한다.
5. 장바구니 전체 변경을 상위에 알린다.



# 2. 설계 기준 
1. 데이터 보관과 화면 표시를 분리한다.
2. 개별 UI는 자신의 화면을 관리한다.
3. 하위 동작은 이벤트로 상위에 알린다.
4. 목록 추가와 삭제는 목록 담당 UI가 한다
5. Form1은 UI 간 연결을 담당한다.


# 3. 구현 흐름
[장바구니 구현 요소]
1. CartItemData 
- 장바구니 항목 하나의 상태를 보관
→ ID, Title, Price, Image (MenuItemData를 전달받을 예정)
→ 실제 수량 저장: Count setter
→ 항목 금액을 계산: SumPrice


2. CartItemControl
- 장바구니 항목 하나를 화면에 표시
→ 표시되는 값: Title, Image, Count, SumPrice
→ 수량 증/감 버튼, 항목 삭제 버튼 입력 처리


3. ShoppingCartControl
- 장바구니 내 CartItemData 목록 총 관리
- CartItemData 생성 및 목록에 저장 
- CartItemControl 생성 및 화면에 추가

메뉴 선택(향후 Form1에서 전달)
→ ShoppingCartControl.AddItem()
→ 기존 ID 검색
    ├─ 새 메뉴: 데이터와 UI 생성
    └─ 기존 메뉴: 수량 변경·UI 갱신
→ CartChanged로 전체 변경 알림



# 4. 실제 구현
## 1. CartItemData
##UI
- 없음. 데이터를 보관하는 모델이다.

##cs
① 아래의 항목 속성으로 구현
- ID, Title, Price, Image, Count, SumPrice

##주의점
① Count 속성은 초기값이 1이고, 1미만이 되는 것을 거부한다.
 (삭제를 하고 싶으면 별도의 삭제 기능을 이용한다.)
② SumPrice는 set이 없는 읽기 전용 속성으로 
 get(조회) 시 Price와 Count을 연산한다.
 (결과를 별도 필드에 저장하지 않는다.)



## 2. CartItemControl
##UI
CartItemControl
├─ FlowRayoutPanel
├─ PictureBox - (name): picBox
├─ label1 - (name): lblTitle
├─ Button1 - (name): btnUP
├─ label2 - (name): lblCount
├─ Button2 - (name): btnDown
├─ label3 - (name): lblSumPrice
└─ Button3 - (name): btnDel


##cs
[이벤트]
① CountChanged 
- 수량에 변화가 있다는 알림
- 실행되는 순서 주의.
  CartItemControl의 버튼(btnUP, btnDown)이 눌러지면
  → CartItemData.Count setter로 값 변경
  → RefreshDisplay()로 화면 갱신
  → CountChanged 이벤트 발생
     (Count가 1일 때 감소를 시도하면 변경이 없어 발생하지 않음)

② DeleteClicked 이벤트
- 삭제 요청 버튼이 눌러졌다 알림


[필드와 속성]
① private CartItemData? _data;
- 연결된 데이터 객체의 참조를 보관하는 필드
- 내부에서 사용하며 외부에서 접근 불가

② public CartItemData? Data => _data;
- _data를 외부 읽기 전용으로 보여줄 속성 제공
- 상위에서 이 UI가 어떤 데이터모델을 참조하는지 검사할 때 사용


[메서드]
① SetData(CartItemData data)
- 부모에게서 CartItemData 객체를 수신
- 참조 저장: _data = data
- RefreshDisplay() 호출

② RefreshDisplay()
- _data의 값을 화면에 표시
  (_data의 값을 picBox, lblTitle, lblCount, lblSumPrice에 넣음)


[이벤트 핸들러]
①② btnUP_Click, btnDown_Click
- _data의 Count 속성 변경 (++,--)
- RefreshDisplay()
- CountChanged 이벤트 발행

③ btnDel_Click()
- _data 존재 확인
- DeleteClicked 이벤트 발행


##주의점
[참조관계]
- _data는 CartItemData 객체를 참조한다.
- _data의 상태를 변경하면
  참조 대상 객체의 상태가 변경된다.
- ShoppingCartControl의 _items와
  CartItemControl의 _data는
  동일한 CartItemData 객체를 참조한다.

[실제 사용]
- _data를 통해 Count를 변경하면
  참조 대상인 CartItemData가 변경된다.
 → ShoppingCartControl의 
  _items가 가진 객체와 같은 객체를 참조하기 때문이다.

- 데이터 값이 바뀌어도 화면은 자동으로 갱신되지 않는다.
→ 따라서 RefreshDisplay()가 필요하다.

[Data속성의 필요성]
- public CartItemData? _data;해서 상위에서 이 UI가
 어떤 데이터모델을 참조하는지 검사할 때 사용할 수도 있지만
 public으로 선언해버리면 control._data = anotherData;와 같이
 참조 중인 객체를 외부에서 교체해버릴 수도 있기 때문에 필요함
- 이렇게 Data 속성을 써서 읽기 전용으로 하면
 외부에서 _data에 다른 객체를 대입할 수는 없지만
 객체 내부의 속성에는 접근할 수 있음
 → control.Data!.Count++;  // 가능
- 즉, 참조를 조회하는 읽기 전용 속성이지
  참조 대상의 내부 변경까지 차단하는 장치는 아님


## 3. ShoppingCartControl
##UI
ShoppingCartControl
├─ RoundedPanel
└─ FlowRayoutPanel 


##cs
[데이터 목록]
① List<CartItemData> _items 
- 선택된 메뉴 항목 상태들을 저장
- 중복 검사·삭제·전체 계산의 기준이다.


[이벤트]
① CartChanged 이벤트
- 장바구니 내부에서 일어난 모든 변경 사실을 알림
- 실제 수량(TotalCount) 및 금액(TotalPrice)을 전달하지 않는다
- 외부 구독자는 필요 시 직접 TotalCount, TotalPrice을 조회한다.

②RaiseCartChanged()
- 이벤트 로직은 아니지만
 CartChanged을 발행 코드를 넣어둠


[읽기 전용 속성]
- set없음. get에서 계산 결과만 반환

①② TotalCount, TotalPrice
→ 현재 선택된 항목들을 기준으로 총량, 총합계 계산


[메서드]
① AddItem(MenuItemData menu)
- 선택된 메뉴가 _items에 있는지 검사
→ FirstOrDefault()를 이용
→_items에서 menu.ID와 같은 항목 검색

"없으면? 새 메뉴"
- CartItemData 객체 'data' 생성 
 → 내부 속성에 menu의 값을 설정, Count = 1

- CartItemControl 객체 'control' 생성
- control.SetData(data)
 →_data에 같은 data 참조 저장
 → RefreshDisplay()로 UI 표시

- control.CountChanged 구독
 → CartItemControl_CountChanged 연결
- control.DeleteClicked 구독
 → CartItemControl_DeleteClicked 연결

- _items 목록에 data 추가
→ 화면에 control추가
→ RaiseCartChanged()

"있으면? 기존 메뉴"
- 검색된 항목을 existingData로 받음
- existingData의 Count++
- flpnl.Controls에서 연결 UI 검색
 → control.Data == existingData 비교
- existingControl?.RefreshDisplay()
- RaiseCartChanged()
- return


② CancelClear() 구현
- 사용자가 전체 취소를 누를 시 동작할 메서드
→ _items.Clear()
→ flpnl.Controls[0] 선택
→ flpnl.Controls.Remove(control)
→ control.Dispose()
→ 컨트롤이 남아 있으면 반복
→ RaiseCartChanged()



[핸들러]
① CartItemControl - 'CountChanged event'
- 자식의 개별 수량 변경 이벤트를
  부모의 장바구니 전체 변경 이벤트로 중계
- RaiseCartChanged()
 → 데이터와 UI는 이미 자식이 갱신했다.
 → 부모가 같은 Count를 다시 바꾸지 않는다.

① CartItemControl - 'DeleteClicked event'
- sender가 CartItemControl인지 확인
- control.Data가 null인지 확인
- _items.Remove(control.Data)
- flpnl.Controls.Remove(control)
- control.Dispose()로 UI자원을 정리
- RaiseCartChanged()



##주의점과 설계 고찰
[Data를 통해 UI를 찾는 이유]
- _items는 CartItemData 목록이므로
  UI 컨트롤이 들어 있지 않다.
→ 기존 항목의 Count를 바꾼 뒤에는
  대응하는 UI를 찾아 갱신해야 한다.
→ 그래서 각 CartItemControl의 Data를
  읽어 같은 객체를 참조하는지 비교한다.


[CartChanged 이벤트 추가 설명]
- Invoke(this, EventArgs.Empty)이므로 자기 자신을 보내지만
직접 TotalCount,TotalPrice를 보내는 것이 아니기 때문에
핸들러를 구현한 쪽에서는 아래와 같이 직접 조회해야한다는 뜻이다.
 int count = cart.TotalCount;
decimal price = cart.TotalPrice;

- 즉, this는 ShoppingCartControl 객체이며
  이벤트 수신자는 sender를 통해
  해당 객체의 public 속성을 조회한다.


[CountChanged 핸들러가 단순한 이유]
- CartItemControl은 자신의 Count 변경과
  화면 갱신을 완료한 후 이벤트를 낸다.
→ 따라서 부모는 그 처리를 반복하지 않고
  장바구니 전체 변경으로 중계하는 것이다.
→ 그래서 RaiseCartChanged()만 호출한다.


[왜 별도 핸들러와 대표 이벤트가 필요한가?]
- 메뉴 추가, 수량 변경, 항목 삭제,
  전체 취소는 모두 장바구니의 변화다.
- 외부가 어떤 때는 CartItemControl에서,
  다른 때는 ShoppingCartControl에서
  이벤트를 직접 받으면 연결이 복잡해진다.

→ 장바구니에 관련된 변경은 
 상위 컨트롤이 모아서 외부에 알리도록 설계했다.
→ 외부는 CartChanged 하나만 구독하면
  장바구니의 변화 사실을 알 수 있다.

→ 전체 수량·금액이 필요한 외부 UI는
 TotalCount와 TotalPrice를 읽는다.

→ 외부에서 장바구니의 내부 구성 요소를
  개별적으로 알 필요가 없도록 하기 위함이다.
→ 코드의 가독성과 역할 경계를 높인다.


[개별 항목 변경에 따른 내부 동작]
- CartItemControl.CountChanged
  → ShoppingCartControl에서 핸들러 구현
    → 핸들러에서 RaiseCartChanged() 호출
      → CartChanged 발행
→ 외부 구독자(연결 예정)


[Dispose의 필요성]
- Remove()는 컨트롤을 화면에서 제거한다.
- Remove()만으로 해당 컨트롤의
  자원 정리가 완료되는 것은 아니다.
- Dispose()는 컨트롤이 사용하는 
 운영체제 자원과 소유 리소스의 정리 절차를 수행한다.
- 자식 컨트롤도 함께 정리된다.
- 객체의 메모리 자체를 즉시 삭제하는 것은 아니며 
 메모리 회수는 GC가 담당한다.
- 현재처럼 삭제 후 재사용하지 않는 UI는
  Remove() 후 Dispose()를 호출한다.



# 5. 현재 구현 상태
- ShoppingCartControl 내부 로직 작성 완료
- CartItemData 연동 코드 작성 완료
- CartItemControl 연동 코드 작성 완료
- Form1과 메뉴 선택 연결 예정
- 전체 동작 검증 예정