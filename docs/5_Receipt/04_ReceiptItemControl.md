# 1. 역할
- 상품 한 종류의 데이터를 전달받아 표시만 하는 UI


# 2. 등장 배경
- 영수증에 표시될 주문한 각 상품에 대한 
상품명, 수량, 항목 합계가 필요하다.
- 데이터와 UI를 분리하는 설계 조건에 따라
데이터 설계는 ReceiptItemData가 담당했다.
- 따라서 UI를 담당하는 ReceiptItemControl가 필요하다.


# 3. 표시할 요소
1. 상품명
- lblTitle
- ReceiptItemData.Title 표시

2. 수량
- lblCount
- ReceiptItemData.Count 표시
- 표시 형식: 3개
 → 포멧팅: $"{receiptItemData.Count}개";

3. 항목 합계
- lblSumPrice
- ReceiptItemData.SumPrice 표시
- 표시 형식: 15,000원
 → 포멧팅: $"{receiptItemData.SumPrice:#,##0}원";


# 4. 데이터 전달 및 표시 흐름
[현재 구현 흐름]
ReceiptForm
→ ReceiptData.Items 순회
→ ReceiptItemControl 동적 생성
→ SetData(ReceiptItemData) 호출
→ 각 Label의 Text 갱신

[설명]
- 외부에서 전달한 ReceiptItemData를 메서드를 통해 받는다.
- 메서드 동작으로 상품 한 종류의 정보를 각 Label에 표시한다
- 바로 화면에 표시만 할 것이니 별도 필드에 보관하지 않는다.

[주의 사항]
- 바로 화면에 표시만 할 것이니 별도의 데이터 필드는 필요없다.
- ReceiptItemData가 보관하는 정보와
ReceiptItemControl이 화면에 표시하는 정보가 반드시 같지 않아도 된다.
 → ReceiptItemData로 전달받은 데이터 중 보여주고 싶은 것만 
    ReceiptItemControl로 보여준다.
 → 여기서는 ReceiptItemData에는 Price가 존재하지만 UI에는 없다.
 → Price를 데이터로는 보관하지만 사용자가 볼 영수증에는 사용자 편의를 위해 표시하지 않는다.


# 5. 다른 구성 요소와의 관계
1. ReceiptItemData
- 영수증 상품 한 종류의 정보를 보관한다.
- Title, Count, SumPrice를 제공한다.

2. ReceiptForm
- 영수증 상품 목록을 순회한다.
- ReceiptItemControl을 동적으로 생성한다.
- 각 컨트롤에 ReceiptItemData를 전달한다.

3. ReceiptData
- Items에 ReceiptItemData 목록을 보관한다.
- ReceiptForm이 이 목록을 사용한다.