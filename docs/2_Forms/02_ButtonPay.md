# 역할
- 사용자가 결제 진행을 요청하는 버튼이다.
- 클릭 입력을 Form1에 전달한다.
- 실제 영수증 생성은 담당하지 않는다.
  → ButtonPay는 클릭을 알리는 역할만 하며,
    영수증 데이터 생성의 시작점이다.
  → 장바구니가 비어 있으면 Form1에서 안내 메시지를 표시한다.


# UI구성
ButtonPay     
└─ RoundedPanel
      └─ Button


# 설계 기준
[클릭과 주문 처리 분리]
- Button은 클릭만 발생시킨다.
- 주문 검사와 영수증 생성은 Form1이 한다.


# 클릭 처리 계획
[1. 장바구니가 비어 있는 경우]
ButtonPay 클릭
→ Form1 이벤트 핸들러 실행
→ ShoppingCartControl.TotalCount 확인
→ 0이면 안내 메시지 표시
→ 영수증 생성 없이 종료

[2. 장바구니에 상품이 있는 경우]
ButtonPay 클릭
→ Form1 이벤트 핸들러 실행
→ ShoppingCartControl에서 항목 조회
→ ReceiptItemData(영수증용 하나의 상품 데이터) 목록 생성
→ ReceiptData(영수증용 전체 데이터) 생성
→ 주문번호와 주문시간 확정
→ ReceiptForm 생성 및 데이터 전달
→ ReceiptForm 표시


# 구현 순서 및 확인 사항
[동작 구현 순서]
1. Form1에 Click 핸들러 연결
2. 장바구니 비어 있음 검사 구현
