# 목차
1. 역할
2. 현재 준비된 것
3. 설계 기준
4. 전체 연결 흐름
5. 실제 구현


# 1. 역할
- 장바구니의 전체 수량 및 전체 금액을 표시한다.
- 외부에서 전달받은 값을 자신의 UI에 반영한다.


# 2. 현재 준비된 것
[ShoppingCartControl]
- CartItemData 목록을 관리한다.
- TotalCount로 전체 수량을 계산한다.
- TotalPrice로 전체 금액을 계산한다.
- 내용이 바뀌면 CartChanged를 발생시킨다.

[Form1]
- MenuBoard의 ItemClicked를 받는다.
- 선택된 MenuItemData를 장바구니에 전달한다.



# 3. 설계 기준
1. 계산과 표시를 분리한다.
- 계산은 기존 ShoppingCartControl이 한다.
- 표시만 OrderTotalControl이 담당한다.

2. Form1은 두 UI를 연결한다.
- CartChanged를 Form1에서 구독한다.
- 변경 알림을 받으면 합계 속성을 조회한다.
- 조회한 값을 OrderTotalControl에 전달한다.

3. 초기 상태를 표시한다.
- 전체 수량 및 전체 금액은 0으로 시작한다.
- 이후 값이 전달되면 화면을 갱신한다.



# 4. 전체 연결 흐름
[장바구니 값 변경]
상황: 메뉴 추가 / 수량 변경 / 항목 삭제/ 전체 취소
→ ShoppingCartControl이 상태 변경
→ RaiseCartChanged()
→ CartChanged 발생
→ Form1 이벤트 핸들러 실행
→ ShoppingCartControl.TotalCount 조회
→ ShoppingCartControl.TotalPrice 조회
→ OrderTotalControl.TotalCountView에 전달
→ OrderTotalControl.TotalPriceView에 전달
→ 내부 Label 갱신

[역할 구분]
1. ShoppingCartControl
→ 장바구니 상태 관리 및 전체 계산

2. Form1
→ 변경 알림 수신 및 값 전달

3. OrderTotalControl
→ 전달받은 값만 화면에 표시



# 5. 실제 구현
[필드]
- private int _count = 0;
- private decimal _price = 0m;
- 전체 수량과 금액을 보관한다.

[속성]
1. TotalCountView
- 외부에서 전체 수량을 전달받는다.
- setter에서 _count에 값을 저장한다.
- RefreshUI()를 호출한다.

2. TotalPriceView
- 외부에서 전체 금액을 전달받는다.
- setter에서 _price에 값을 저장한다.
- RefreshUI()를 호출한다.

[메서드]
1. RefreshUI()
- 화면UI에 들어갈 값을 포멧해서 표시한다.

[생성자]
- InitializeComponent()를 호출한다.
- RefreshUI()를 호출한다.
- 초기 화면에 0과 0원을 표시한다.

[이벤트]
- 자체 커스텀 이벤트는 사용하지 않는다.
- CartChanged도 직접 구독하지 않는다.
- Form1을 통해 계산 결과만 전달받는다.