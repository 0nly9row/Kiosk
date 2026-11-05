# 영수증 발생 상황
- 사용자가 결제 버튼을 누를때 발생


# 역할
- 영수증 데이터를 화면에 표시하는 UI


# 코드에서 사용할 명칭
1. ReceiptItemData
- 영수증에 출력할 하나의 상품 정보 데이터 모델 

2. ReceiptData
- 영수증 전체의 정보 데이터 모델

3. ReceiptItemControl
- 영수증에 출력할 하나의 상품 UI

4. ReceiptForm
- 화면에 표시할 영수증 전체 정보 UI

5. ButtonPay
- 결제 UI 

6. ButtonClear
- 취소 UI


# 실제 구현 전 주의 사항
[1. 데이터 조회]
- 현재 _items는 ShoppingCartControl 내부 필드이다.
 Form1이 직접 접근할 수 없으므로 Public메서드 또는 읽기 전용이 필요하다
- 내부 목록 자체를 외부에서 수정하게 하지 않는다.

[2. 영수증 시점]
- 결제 버튼을 누른 순간의 값을 복사한다.
- ReceiptData를 만들 때 주문번호와 시간을 확정한다.

[3. 표시 이후 처리]
- 영수증 폼을 닫으면 장바구니를 초기화한다.
- ReceiptForm은 영수증 표시만 담당한다.
- 장바구니 초기화는 Form1에서 아래처럼 처리한다. 
→ ① ReceiptForm.ShowDialog(this)
→ ② 사용자가 X 버튼으로 닫기
→ ③ ShowDialog() 반환
→ ④ Form1에서 CancelClear()
→ ⑤ CartChanged 발생
→ ⑥OrderTotalControl 갱신

[4. 결제 범위]
- 현재 계획의 '결제'는 영수증 표시까지이며 
 실제 승인 처리, 결제 실패, DB 저장은 별도로 다룬다.


# 계획 진행 사항
## 1. ButtonPay (완료)
- 클릭 이벤트 발행
- 영수증 데이터 생성 및 영수증 폼 표시를 시작함
  (주의. ButtonPay는 클릭을 알리는 역할만 한다.)
→ 장바구니 항목이 없으면: MessageBox.Show("상품을 담아주세요!");
→ Button: 결제 (text: 결제)


## 2. ButtonClear (완료)
- 클릭 이벤트 발행
- ShoppingCartControl.CancelClear() 호출
- CartChanged를 통해 총량·총액도 갱신
→ Button: 취소 (text: 취소)


## 3. ReceiptItemData (완료)
- Property: 상품명
- Property: 단가
- Property: 수량
- Property: 항목 합계


## 4. ReceiptItemControl (완료)
- ReceiptItemData 하나를 전달받는다.
- 전달받은 값으로 자신의 UI 갱신

[ReceiptItemControl]
├─ Label: 상품명 ((name): lblTitle)
├─ Label: 상품 하나의 총 수량 ((name): lblCount)
└─ Label: 상품 하나의 총 합계 ((name): lblSumPrice)


## 5. ReceiptData (완료)
- Property: 주문번호
- Property: 주문시간
- List<ReceiptItemData>: 영수증 항목 목록
- Property: 상품 전체 수량
- Property: 상품 전체 금액


## 6. ReceiptForm (완료)
- ReceiptData를 전달받는다. 
- 항목 목록을 순회하며 UI를 동적으로 생성한다.
- FlowLayoutPanel 등에 각 UI를 배치한다.

[상단] 주문 정보
├─ Label: 상점명 ((name): lblStoreName)
├─ Label: 상점 소개 ((name):lblDescription)
├─ Label: 주문 번호 ((name):lblOrderNumber)
└─ Label: 주문 시간 ((name):lblOrderTime)

 [중단] 주문 상품 목록
└─ FlowLayoutPanel ((name):flpnl)
      ├─ ReceiptItemControl (런타임)
      ├─ ReceiptItemControl (런타임)
      └─ ... (상품 종류만큼 생성)

 [하단] 주문 합계
├─ Label: 상품 총 수량 ((name):lblTotalCount)
└─ Label: 상품 총 합계 ((name):lblTotalPrice)


# 실제 코드 흐름 
## 1. 사용자가 결제 버튼 클릭 (완료)
 → 이벤트 발생

[① Form1] (완료)
- Form1이 ButtonPay 클릭 이벤트 핸들러 구현 
  → 장바구니 비어 있음 검사 
  → 장바구니 상품이 있다면 다음 단계 진행 

[② ShoppingCartControl] (완료)
- 현재 장바구니 목록을 순회한다.
- 각 CartItemData에서 필요한 값을 추출한다.
- ReceiptItemData 객체로 변환한다.
- List<ReceiptItemData>를 구성한다.
- 영수증용 상품 목록을 Form1에 전달한다.

[③ Form1] (완료)
- ReceiptData 객체를 생성한다.
- 주문번호와 주문시간을 확정한다.
- 영수증용 상품 목록을 Items에 할당한다.
- 전체 수량과 전체 금액을 할당한다.
- 완성된 ReceiptData를 ReceiptForm에 전달한다.
- ShowDialog(this)로 영수증을 표시한다.

[④ ReceiptForm] (완료)
  → ReceiptForm에서 ReceiptItemData 목록(Items)을 순회
  → ReceiptItemControl 동적 생성
  → ReceiptItemData 목록의 값을
      ReceiptItemControl에 전달에서 화면에 표시
  → 주문번호, 주문시간, 전체 수량 및 금액 표시

[⑤ 영수증 종료 후 처리] (완료)
- 사용자가 기본 X 버튼으로 폼을 닫는다.
- ShowDialog()가 반환된다.
- Form1에서 CancelClear()를 호출한다.
- CartChanged 이벤트가 발생한다.
- OrderTotalControl의 합계 UI가 갱신된다.


## 2. 사용자가 취소 버튼 클릭 (완료)
[ButtonClear]
- Form1이 ButtonClear 클릭 이벤트 핸들러 구현
  → ShoppingCartControl.CancelClear() 호출
  → CartChanged 발생
  → OrderTotalControl 화면 갱신


+) 메뉴판 구조와 비교
[유사한 구조]
- 메뉴판: MenuItemData → MenuItemControl → MenuBoard
- 영수증: CartItemData → ReceiptItemData → ReceiptData → ReceiptForm→ ReceiptItemControl

[차이점]
- 메뉴판은 미리 준비된 메뉴 목록을 표시
- 영수증은 결제 시점의 장바구니 데이터를 기준으로 생성
- 영수증은 영수증 데이터를 생성하지 않고 전달받은 데이터를 화면에 표시만 함.