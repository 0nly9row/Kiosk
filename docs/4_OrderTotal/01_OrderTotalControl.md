# 목차
1. 역할
2. 현재 준비된 것
3. 설계 기준
4. 전체 연결 흐름



# 역할
- 장바구니의 전체 수량을 표시한다.
- 장바구니의 전체 금액을 표시한다.
- 외부에서 전달받은 값을 자신의 UI에 반영한다.



# 현재 준비된 것
[ShoppingCartControl]
- CartItemData 목록을 관리한다.
- TotalCount로 전체 수량을 계산한다.
- TotalPrice로 전체 금액을 계산한다.
- 내용이 바뀌면 CartChanged를 발생시킨다.

[Form1]
- MenuBoard의 ItemClicked를 받는다.
- 선택된 MenuItemData를 장바구니에 전달한다.



# 설계 기준
1. 계산과 표시를 분리한다.
- 계산은 기존 ShoppingCartControl이 한다.
- 표시만 OrderTotalControl이 담당한다.

2. Form1은 두 UI를 연결한다.
- CartChanged를 Form1에서 구독한다.
- 변경 알림을 받으면 합계 속성을 조회한다.
- 조회한 값을 OrderTotalControl에 전달한다.

3. 초기 상태를 표시한다.
- 전체 수량은 0으로 시작한다.
- 전체 금액은 0원으로 시작한다.
- 이후 값이 전달되면 화면을 갱신한다.



# 전체 연결 흐름
[장바구니 값 변경]
메뉴 추가 / 수량 변경 / 항목 삭제/ 전체 취소
→ ShoppingCartControl이 상태 변경
→ RaiseCartChanged()
→ CartChanged 발생
→ Form1 이벤트 핸들러 실행
→ ShoppingCartControl.TotalCount 조회
→ ShoppingCartControl.TotalPrice 조회
→ OrderTotalControl.Count에 전달
→ OrderTotalControl.TotalPrice에 전달
→ 내부 Label 갱신

[역할 구분]
ShoppingCartControl
→ 장바구니 상태 관리 및 전체 계산

Form1
→ 변경 알림 수신 및 값 전달

OrderTotalControl
→ 전달받은 값만 화면에 표시