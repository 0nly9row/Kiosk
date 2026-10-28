# 역할
- 사용자가 현재 장바구니 취소를 요청한다.
- 클릭 입력을 Form1에 전달한다.
- 직접 장바구니 데이터를 삭제하지 않는다.
  → ButtonClear는 클릭을 알리는 역할만 하며,
    장바구니 데이터 삭제의 시작점이다.
  → 클릭 이벤트 핸들러에서 
    ShoppingCartControl.CancelClear()를 호출한다.


# UI구성
ButtonClear     
└─ RoundedPanel
      └─ Label


# 설계 기준
[클릭과 주문 처리 분리]
- Button은 클릭만 발생시킨다.
- Form1은 장바구니에 초기화를 요청한다.
- 실제 삭제는 ShoppingCartControl이 한다.

[실제 구현]
- ButtonClick 대표 이벤트 선언
- AddButtonClick(this) 생성자에서 호출
- 내부 컨트롤의 Click 이벤트 재귀 연결
- 클릭 시 ButtonClick 발생


# 클릭 처리 계획
btnClear 클릭
→ Form1 이벤트 핸들러 실행
→ ShoppingCartControl.CancelClear() 호출

[이로 인한 영향]
→ _items.Clear()
→ CartItemControl 화면 제거 및 정리
→ RaiseCartChanged()
→ CartChanged 발생
→ Form1의 기존 핸들러 실행
→ TotalCount와 TotalPrice 조회
→ OrderTotalControl에 0 전달
→ 수량 0, 금액 0원 표시


# 구현 순서 및 확인 사항
[동작 구현 순서]
1. btnClear UI 배치
2. Form1에 Click 핸들러 연결
