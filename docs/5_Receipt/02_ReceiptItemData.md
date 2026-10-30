# 역할
- 영수증에 들어갈 상품 한 종류의 데이터를 보관하는 모델이다.
- 결제 요청 시점의 상품 정보를 
 영수증용 값으로 전달하는 데 사용한다
- 영수증 상품 목록의 한 항목에 해당한다


# 등장 배경
- 결제 버튼을 누르면 영수증을 생성해야 한다.
- 영수증에는 장바구니의 상품 정보가 필요하다.

[현재 데이터 모델]
1. MenuItemData
- ID, Title, Price, Image

2. CartItemData
- ID, Title, Price, Image, Count, SumPrice

[새로운 모델이 필요한 이유]
- 영수증에는 결제 요청 시점의 정보가 필요하다.
- 필요한 값만 별도로 보관할 ReceiptItemData를 만든다.


# 보관할 데이터
1. 상품명
- Title (string)

2. 상품 한 개의 단가 
- Price (decimal)

3. 주문한 수량
- Count (int)
- 주문한 수량

4. 해당 상품의 합계 금액
- SumPrice (decimal)
- 단가 × 수량에 해당하는 값


# 데이터 생성 및 전달 계획
[전제 조건]
- 사용자가 결제하기를 클릭한다.
- Form1에서 장바구니가 비어있는지 검사하는 로직을 통과한다.

[예정 흐름]
ShoppingCartControl의 CartItemData 목록
→ 각 항목에서 필요한 값 추출
→ ReceiptItemData 객체 생성
→ List<ReceiptItemData> 구성
→ Form1에 상품 목록 전달
→ ReceiptData.Items에 포함
→ ReceiptForm으로 전달


#  다른 구성 요소와의 관계 (이후 예정도 포함)
1. ShoppingCartControl / CartItemData
- 현재 주문 중인 상품 정보를 가진다.
- 영수증에 필요한 상품 값을 제공한다.

2. Form1
- 결제 요청을 받아 장바구니를 검사한다.
- 이후 영수증 전체 데이터를 구성한다.

3. ReceiptData (예정)
- List<ReceiptItemData> Items를 통해
  여러 영수증 상품을 하나로 묶는다.
- 주문번호, 주문시간, 전체 합계 등은
  ReceiptData에서 담당할 예정이다.

4. ReceiptItemControl (예정)
- ReceiptItemData 한 개를 받아
  영수증의 상품 한 줄을 표시할 예정이다.

5. ReceiptForm (예정)
- ReceiptData.Items를 순회하여
  ReceiptItemControl을 반복 생성한다.