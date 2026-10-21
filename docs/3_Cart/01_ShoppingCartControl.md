ShoppingCartControl.md를 아래처럼 적는 거 어떤가?

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



[장바구니 실제 구현]
1. CartItemData
# UI
- 없음. 데이터를 보관하는 모델이다.

# cs
① 아래의 항목 속성으로 구현
 → ID, Title, Price, Image, Count, SumPrice

# 주의점
① Count 속성은 초기값이 1이고, 1미만이 되는 것을 거부한다.
 (삭제를 하고 싶으면 별도의 삭제 기능을 이용한다.)
② SumPrice는 set이 없는 읽기 전용 속성으로 
 get(조회) 시 Price와 Count을 연산한다.
 (결과를 별도 필드에 저장하지 않는다.)



2. CartItemControl
# UI
CartItemControl
├─ FlowRayoutPanel
├─ PictureBox - (name): picBox
├─ label1 - (name): lblTitle
├─ Button1 - (name): btnUP
├─ label2 - (name): lblCount
├─ Button2 - (name): btnDown
├─ label3 - (name): lblSumPrice
└─ Button3 - (name): btnDel


# cs
[이벤트]
① CountChanged 
→ 수량에 변화가 있다는 알림
→ 화면, 내부 저장 공간 모두 변경되었을 때 발행

② DeleteClicked 이벤트
→ 삭제 요청 버튼이 눌러졌다 알림


[필드와 속성]
① private CartItemData? _data;
→ 연결된 데이터 객체의 참조를 보관하는 필드
→ 외부에서 접근 불가

② public CartItemData? Data => _data;
→ _data를 외부 읽기 전용으로 보여줄 속성 제공
→ 상위에서 이 UI가 어떤 데이터모델을 참조하는지 검사할 때 사용


[메서드]
① SetData(CartItemData data)
→ 부모에게서 CartItemData 객체를 수신
→ 참조 저장: _data = data
→ RefreshDisplay() 호출

② RefreshDisplay()
→ _data의 값을 화면에 표시
  (_data의 값을 picBox, lblTitle, lblCount, lblSumPrice에 넣음)


[이벤트 핸들러]
①② btnUP_Click, btnDown_Click
→ _data의 Count 속성 변경 (++,--)
→ RefreshDisplay()
→ CountChanged 이벤트 발행

③ btnDel_Click()
→ _data 존재 확인
→ DeleteClicked 이벤트 발행


# 주의점
[참조관계]
- _data을 변경시키면 
 실제 참조되는 CartItemData객체도 변경됨

[실제 사용]
- _data를 통해 Count를 변경하면
  참조 대상인 CartItemData가 변경된다.
 → ShoppingCartControl의 
  _items가 가진 객체와 같은 객체를 참조하기 때문이다.

- 데이터 값이 바뀌어도 화면은 자동으로 갱신되지 않는다.
→ 따라서 RefreshDisplay()가 필요하다.





3. ShoppingCartControl
# UI
ShoppingCartControl
├─ RoundedPanel
└─ FlowRayoutPanel 


# cs
[데이터 목록]
① List<CartItemData> _items 
- 선택된 메뉴 항목 상태들을 저장
- 중복 검사·삭제·전체 계산의 기준이다.


[이벤트]
① CartChanged 이벤트
- 장바구니 내부 변경을 알림

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
 → CartItem_CountChanged 연결
- control.DeleteClicked 구독
 → CartItem_DeleteClicked 연결

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


[핸들러]
① CartItemControl - 'CountChanged event'
- RaiseCartChanged()

[DeleteClicked]
→ _items목록에서 지움
→ 화면에서 지움
→ RaiseCartChanged()

- CancelClear() 구현
→ 사용자가 전체 취소를 누를 시 동작할 메서드
→ 내부 저장소 및 화면에 있는 메뉴 정보를 모두 지운다
→ RaiseCartChanged()


# 주의점
- 선택된 메뉴가 있는 경우에서
 화면에 배치된 항목을 찾을 때 CartItemControl의 Data로 읽음
 읽기 전용 속성인 Data의 쓰임새임.
 실제 _data를 가져오게 되면 실제 객체가 옮겨다니니
 이렇게 읽기 전용으로 읽기만 하는 것임.

- CountChanged
→ 여기서 RaiseCartChanged 말고 별 다른 동작이 없는 이유는
CartItemControl 이나 CartItemdata에서 담당해야할 것은
자신들의 내부 동작으로 다 끝냈기 때문에
이렇게 적었다. 
그럼 여기서 핸들러를 왜 구현했지?
굳이 행동할 것이 아닌데 왜 핸들러를 구현했나?
내가 생각하기엔 상위로 올려줄 때,
장바구니에서 올라가는 것으로 묶기 위해서임.
그러니까
삭제 버튼을 눌렀을 때나 전체 취소를 눌렀을 때도 마찬가진데
장바구니 내에서 변경이 생겼고 
외부에서 이것에 대해 장바구니 내부 상태를 전달받아야할 때가 있을 것이다. 그런데 이때 CartItemControl에서 전달받고,
ShoppingCartControl에서 전달받을 때가 있으면 
장바구니라는 큰 틀에서 전달받는 것과 다르게 혼동이 생길 수 있따.
그렇기 때문에 장바구니 내부에서 일어난 행동에 대한 결과가 외부에서 알려한다면, 장바구니컨트롤 하나에서 결과들을 모아 외부에서 가져가게하면 가독성이 좋다.





