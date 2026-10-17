# 목차
1. 도입 배경
2. 역할
3. 설계 기준
4. 보관할 데이터
5. 구현 흐름
6. 다른 구성 요소와의 관계


# 1. 도입 배경
[현재까지의 구현]
- MenuItemData는 메뉴 하나의 정보를 보관한다.
- MenuBoard는 선택한 MenuItemControl에서
 MenuItemData의 정보만 Form1에 이벤트로 전달한다.
 → Form1은 해당 데이터를 장바구니에 전달할 예정이다.

[새 모델이 필요한 이유]
- 메뉴 자체의 정보와 장바구니 상태는 다르다.
- 같은 메뉴라도 장바구니에는 수량이 필요하다.
- 이 수량을 UI 내부 값으로 보관하지 않으려 한다.
  → 그래서 장바구니 항목 데이터를 별도로 둔다.

MenuItemData → 메뉴 자체의 정보
CartItemData → 담긴 메뉴의 정보와 수량



# 2. 역할
[CartItemData란?]
- 장바구니에 담긴 메뉴 한 종류의 정보를 보관하는 Data Model이다.
- 항목 하나의 데이터를 표현한다.
 → 메뉴 ID, 메뉴명, 단가, 이미지, 현재 수량
- 같은 메뉴를 다시 선택하면 
 ShoppingCartControl이 기존 CartItemData의 Count를 증가시킨다

[담당하지 않는 것]
- 버튼 클릭을 감지하지 않는다. 
- 삭제 버튼 이벤트를 발생시키지 않는다.
- 여러 장바구니 항목을 직접 관리하지 않는다.
- 장바구니 전체 수량과 금액을 계산하지 않는다.



# 3. 설계 기준
1. 데이터와 UI 분리
- CartItemData는 실제 항목 정보를 보관한다.
- CartItemControl은 전달된 값을 화면에 표시한다.
- 화면에 보여지는 글자는 실제 데이터 기준이 아니다.
  → 데이터의 기준은 CartItemData이다.

2. 책임 구분
- CartItemControl: 버튼 클릭 수신
- CartItemData: 실제 데이터 저장
  → 실제 데이터를 기준으로 UI를 갱신한다.
- ShoppingCartControl: 여러 항목 목록 관리

3. 자동 갱신 여부
- Count 변경만으로 화면이 자동 갱신되지는 않는다.
- 화면 갱신 방식은 CartItemControl에서 설계한다.



# 4. 보관할 데이터
[설계 예정 속성]
1. ID : int
- 메뉴를 구분하는 식별값이다.
- 같은 메뉴가 담겨 있는지 찾을 때 사용한다.

2. Title : string
- 메뉴명을 보관한다.
- CartItemControl에 표시할 정보이다.

3. Price : decimal
- 메뉴 한 개의 가격을 보관한다.
- 해당 항목의 금액 계산에 사용한다.

4. Image : Image?
- 메뉴 이미지를 보관한다.
- CartItemControl에 표시할 정보이다.

5. Count : int
- 장바구니에 담긴 현재 수량이다.
- 새 항목을 만들 때 1로 시작할 계획이다.
- 수량은 1 이상으로 유지할 계획이다.
- 항목 제거는 수량 0이 아닌 삭제로 처리한다.


[계산되는 정보]
1. 항목 총 금액 = Price × Count
- 읽기 전용 계산 속성으로 구현
  → 별도로 호출하는 메서드가 아니며, SumPrice를 읽을 때 계산된다.
  → 예시: public decimal SumPrice=> Price * Count;

- Price 또는 Count가 변경되면 다음 SumPrice 조회에 반영됨.
- CartItemControl은 SumPrice를 화면에 표시한다.
- ShoppingCartControl은 각 항목의 SumPrice를 더해 전체 금액을 구한다.


[최소 수량]
- 수량 1에서 감소해도 0으로 만들지 않는다.
- 항목을 없앨 때에는 삭제 기능을 사용한다.



# 5. 구현 흐름
[새 메뉴 선택]
MenuItemControl 클릭

→ MenuBoard.MenuClicked 수신
→ MenuBoard가 MenuItemData 검색
→ MenuBoard.ItemClicked 발생

→ Form1에서 MenuItemData 수신

→ ShoppingCartControl에 전달
→ 동일 ID가 없는지 확인
→ CartItemData 생성, Count = 1
→ CartItemControl 생성 및 표시


[기존 메뉴 다시 선택]
MenuItemData 전달
→ ShoppingCartControl에서 ID 검색
→ 같은 ID의 CartItemData 확인
→ 해당 항목 Count 증가
→ CartItemControl 화면 갱신


[수량 버튼 클릭]
CartItemControl에서 클릭 감지
→ 유효한 수량인지 확인
→ CartItemData.Count 변경
→ CartItemControl 화면 갱신
→ CountChanged로 변경 알림
→ ShoppingCartControl 합계 갱신

- 실제 처리 메서드와 이벤트 형태는
  CartItemControl 구현 시 확정한다.


# 6. 다른 구성 요소와의 관계
[MenuItemData]
- 원래 메뉴의 ID, 이름, 단가, 이미지 보관

[CartItemData]
- 선택된 메뉴의 정보와 수량 보관
- 항목 한 종류의 금액 계산

[CartItemControl]
- CartItemData 내용을 화면에 표시
- 수량 변경 및 삭제 버튼 입력 처리
- 자기 화면 갱신과 변경 알림 담당

[ShoppingCartControl]
- CartItemData 목록 관리
- 중복 메뉴 확인과 새 항목 추가
- 항목 삭제 및 전체 수량·금액 계산

[Form1]
- MenuBoard와 장바구니 사이 데이터 전달
