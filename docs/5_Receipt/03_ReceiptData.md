# 1. 역할
- 영수증 전체 데이터를 하나로 묶어 보관하는 데이터 모델이다.
- 결제 요청 시점의 주문 결과를 ReceiptForm에 전달하는데 사용한다.
- ReceiptItemData 목록을 저장한다.


# 2. 등장 배경
- ReceiptItemData는 한 종류의 상품 정보만 보관한다.
- 영수증을 구성하려면 상품 목록 이외로 
 주문 번호, 주문 시간, 전체 합계 등이 필요하다.
- 이 값들을 개별적으로 전달하지 않고
  결제 요청 시점에 하나의 데이터 객체로 묶기 위해 생성한다.
- 영수증 정보가 추가되면 속성 추가를 통해 확장한다.


# 3. ReceiptForm 자체에서 영수증 데이터 관리를 하지 않는 이유
1. 영수증 데이터는 UI가 없어도 존재하게 만들기 위함

2. 기존의 설계 원칙과 일치
MenuItemData와 MenuItemControl을 분리했다.
CartItemData와 CartItemControl을 분리했다.
따라서 ReceiptData와 ReceiptForm을 분리한다.

→ 확정된 결제 시점의 장바구니 정보를 재사용하기 위해서는
 이를 보관할 수단이 필요하다.
- 확정된 정보를 보관하는 수단은 아래와 같다.
① ReceiptData 객체
② Form1의 별도 필드
③ 다른 주문 데이터 모델
④ DB 저장
 - 일관된 설계 기준에 따라 데이터 모델로 보관하는 것이 맞다.

[ReceiptData의 보관 범위]
생성된 ReceiptData 객체는
프로그램 실행 중에는 데이터를 저장하고 있지만 
프로그램을 종료하면 데이터는 삭제된다.


# 4. 보관 데이터
1. 매장명
- StoreName (string)

2. 매장 설명
- StoreDescription (string)

3. 주문번호
- OrderNumber (string)

4. 주문시간
- OrderTime (DateTime)

5. 영수증 상품 목록
- Items (List<ReceiptItemData>)
- 주문한 상품들의 상세 정보를 보관한다.

6. 전체 상품 수량
- TotalCount (int)

7. 전체 주문 금액
- TotalPrice (decimal)


# 5. 데이터 생성 및 전달 계획
[전제 조건]
- 사용자가 결제하기를 클릭한다.
- Form1에서 장바구니가 비어있는지 검사하는 로직을 통과한다.
- 영수증용 상품 목록을 준비한다.

[예정 흐름]
1. ShoppingCartControl
→ ShoppingCartControl의 상품 정보
→ List<ReceiptItemData> 구성

2. Form1
→ ReceiptData 생성
→ 주문번호, 주문시간 등 값 할당
→ Items에 영수증 상품 목록 할당
→ 전체 수량과 전체 금액 할당
→ ReceiptForm에 ReceiptData 전달

3. ReceiptForm
→ ReceiptData 객체 수신
→ 주문 정보 및 상품 목록 확인
→ 영수증 UI 구성



# 6. 다른 구성 요소와의 관계 (이후 예정도 포함)
1. ShoppingCartControl / CartItemData
- 현재 주문 중인 상품 정보를 가진다.
- 영수증 상품 목록 생성에 필요한
  값의 출처가 된다.

2. ReceiptItemData
- 영수증 상품 한 종류의 데이터다.
- ReceiptData.Items에 여러 개 담긴다.

3. Form1
- 결제 요청을 받아 장바구니를 검사한다.
- ReceiptData 객체를 생성한다.
- 필요한 주문 결과 값을 채운다.
- 완성된 객체를 ReceiptForm에 전달한다.

4. ReceiptItemControl
- ReceiptItemData 한 개를 받아
  상품 한 줄을 표시할 예정이다.

5. ReceiptForm
- 전달받은 ReceiptData를 읽는다.
- 주문 정보와 전체 합계를 화면에 표시한다.
- Items를 순회하여 상품 UI를 구성한다.

[주요 역할 정리]
1. Form1 → 영수증 데이터 생성 및 전달
2. ReceiptItemData → 영수증용 하나의 상품 데이터 보관
3. ReceiptData → 영수증 전체 데이터 보관
4. ReceiptItemControl → 영수증용 하나의 상품 컨트롤 표시
5. ReceiptForm → 영수증 전체 데이터 표시
