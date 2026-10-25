# 영수증 발생 상황
- 사용자가 결제 버튼을 누를때 발생

# 영수증 흐름 구상 
- 현재 장바구니 목록을 순회하며 
영수증용 각 상품 데이터 모델 구현로 변환한다.
- 그리고 각 상품 데이터 모델을 포함한 
영수증 전체 데이터 모델을 만든다.
- 영수증폼에서 영수증용 전체 데이터를 전달받아
화면을 구성한다 

- MenuItemData → MenuItemControl → MenuBoard구조와 유사
→ 차이점은 메뉴판은 미리 준비된 메뉴 목록을 표시하지만
  영수증은 결제 시점의 장바구니 데이터를 기준으로 생성된다는 점.


# 계획 실천 준비
- 결제 버튼 (취소 버튼도 함께 구현)
- 영수증용 각 상품 데이터 모델 구현
- 영수증용 각 상품 컨트롤 구현
- 영수증용 전체 데이터 목록 모델 구현
- 영수증 폼에서 데이터 모델을 전달받아 영수증UI화면 구성


# 코드에서 사용할 명칭 및 역할 정리
[1. ReceiptItemData]
- 영수증에 출력할 하나의 상품 정보 데이터 모델 
→ Property: 상품명
→ Property: 단가
→ Property: 수량
→ Property: 항목 합계

[2. ReceiptData]
- 영수증 전체의 정보 데이터 모델
→ Property: 주문번호
→ Property: 주문시간
→ List<ReceiptItemData>: 영수증 항목 목록
→ Property: 상품 전체 수량
→ Property: 상품 전체 금액

[3. ReceiptItemControl]
- 영수증에 출력할 하나의 상품 UI
- ReceiptItemData 하나를 전달받는다.
- 전달받은 값으로 자신의 UI 갱신
→ Label: 상품명 (name: lblTitle)
→ Label: 상품 하나의 총 수량 (name: lblCount)
→ Label: 상품 하나의 총 합계 (name: lblSumPrice)


[4. ReceiptForm]
- 화면에 표시할 영수증 전체 정보 UI
- ReceiptData를 전달받는다. 
- 항목 목록을 순회하며 UI를 동적으로 생성한다.
- FlowLayoutPanel 등에 각 UI를 배치한다.

[상단] 주문 정보
├─ Label (lblStoreName)
├─ Label (lblDescription)
├─ Label (lblOrderNumber)
└─ Label (lblOrderTime)

 [중단] 주문 상품 목록
└─ FlowLayoutPanel (flpnl)
      ├─ ReceiptItemControl (런타임)
      ├─ ReceiptItemControl (런타임)
      └─ ... (상품 종류만큼 생성)

 [하단] 주문 합계
├─ Label (lblTotalCount)
└─ Label (lblTotalPrice)


[5. ButtonPay]
- 결제 UI 
- 클릭 이벤트 발행
- 영수증 데이터 생성 및 영수증 폼 표시를 시작함
  (주의. ButtonPay는 클릭을 알리는 역할만 한다.)
→ 장바구니 항목이 없으면: MessageBox.Show("상품을 담아주세요!");
→ Button: 결제 (text: 결제)


[6. ButtonClear]
- 취소 UI
- 클릭 이벤트 발행
- ShoppingCartControl.CancelClear() 호출
- CartChanged를 통해 총량·총액도 갱신
→ Button: 취소 (text: 취소)



# 실제 코드 흐름 예상
1. 사용자가 결제 버튼 클릭
 → 이벤트 발생

[Form1]
- Form1이 ButtonPay 클릭 이벤트 핸들러 구현
  → ShoppingCartControl에 현재 목록 요청
  → ReceiptItemData 목록 생성
  → ReceiptData 객체 생성

  → ReceiptForm 생성
  → ReceiptForm에 ReceiptData 전달
  → ReceiptForm 표시

[ReceiptForm]
  → ReceiptForm에서 ReceiptItemData 목록을 순회
  → ReceiptItemControl 동적 생성
  → ReceiptItemData 목록의 값을
      ReceiptItemControl에 전달에서 화면에 표시
  → 주문번호, 주문시간, 전체 수량 및 금액 표시


2. 사용자가 취소 버튼 클릭
[ButtonClear]
- Form1이 ButtonClear 클릭 이벤트 핸들러 구현
  → ShoppingCartControl.CancelClear() 호출
  → CartChanged 발생
  → OrderTotalControl 화면 갱신



# 실제 구현 전 주의 사항
1. 데이터 조회
- 현재 _items는 ShoppingCartControl 내부 필드이다.
 Form1이 직접 접근할 수 없으므로 Public메서드 또는 읽기 전용이 필요하다
- 내부 목록 자체를 외부에서 수정하게 하지 않는다.

[2. 영수증 시점]
- 결제 버튼을 누른 순간의 값을 복사한다.
- ReceiptData를 만들 때 주문번호와 시간을 확정한다.

[3. 표시 이후 처리]
- 영수증 폼을 닫을 때 자동으로
  장바구니를 비울지에 대한 고민이 필요하다.
- 영수증이 생성됐다는 이유만으로
  임의로 CancelClear()를 호출하지 않는다.

[4. 결제 범위]
- 현재 계획의 '결제'는 영수증 표시까지이며 
 실제 승인 처리, 결제 실패, DB 저장은 별도로 다룬다.
