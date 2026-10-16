# 목차
0. 필요성
1. 역할
2. 설계 기준 
3. 구현 흐름 계획
4. 다른 구성 요소와의 관계

# 0. 필요성
- MenuBoard는 어떤 메뉴를 선택했는지만 상위 화면에 알려준다.
- 선택한 메뉴를 보관하고 관리할 곳은 없다.

→ 메뉴를 보관하고 관리할 상위 컨트롤이 필요한 상황



# 1. 역할 
1. 여러 장바구니 항목을 관리하는 UserControl이다.
2. 전달받은 메뉴가 이미 담겨있는 메뉴인지 확인한다.
  → 새 메뉴라면 장바구니 항목을 추가
  → 같은 메뉴라면 기존 수량을 증가
3. 항목 삭제 요청을 받아 실제로 제거한다.
4. 전체 수량과 총 금액을 계산한다.
5. 장바구니 전체 변경을 상위에 알린다.



# 2. 설계 기준 
1. 데이터 보관과 화면 표시를 분리한다.
2. 개별 UI는 자신의 화면을 관리한다.
3. 하위 동작은 이벤트로 상위에 알린다.
4. 목록 추가와 삭제는 목록 담당 UI가 한다
5. Form1은 UI 간 연결을 담당한다.



# 3. 구현 흐름 계획
[장바구니 내 필요한 요소]
1. 장바구니 항목 하나를 화면에 표시
→ CartItemControl 

2. 장바구니 항목 하나의 상태를 보관
→ CartItemData


[메뉴 선택]
MenuItemControl 클릭
→ MenuBoard에서 MenuClicked 수신
→ ID로 MenuItemData 검색
→ MenuBoard.ItemClicked 발생
→ Form1에서 MenuItemData 수신
→ ShoppingCartControl에 전달


[장바구니 항목 추가]
MenuItemData 수신
→ 메뉴 ID로 기존 항목 확인
→ 새 메뉴면 항목 데이터 및 UI 추가
→ 기존 메뉴면 수량 증가
→ 장바구니 전체 값 다시 계산
→ 변경 사실을 상위에 전달


[수량 변경]
CartItemControl에서 버튼 클릭
→ CartItemControl에서 항목의 수량 변경 처리
→ ShoppingCartControl이 변경 확인
→ 전체 수량 및 총 금액 다시 계산
→ 상위 화면에 변경 알림


[삭제]
CartItemControl에서 삭제 요청
→ ShoppingCartControl이 요청 수신
→ 해당 항목 데이터 및 화면 제거
→ 전체 수량 및 총 금액 다시 계산
→ 상위 화면에 변경 알림


[계산 기준]
- 이전 총액을 저장해두고, 계속 더하거나 빼는 방식말고
 현재 항목 목록을 기준으로 계산을 새로 하는 방식을 택한다

1. 총 수량
- 각 항목 수량을 모두 더한다.

2. 총 금액 
- 각 항목의 단가 x 수량을 곱한 뒤 모두 더한다.



# 4. 다른 구성 요소와의 관계
[MenuBoard]
- 메뉴 목록 표시 및 선택 알림을 담당한다.
- ItemClicked로 MenuItemData를 전달한다.

[Form1]
- MenuBoard의 ItemClicked를 받는다.
- 받은 MenuItemData를 장바구니에 넘긴다.
- 두 UI 사이를 연결하는 역할만 맡는다.

[CartItemData]
- 장바구니 항목 하나의 상태를 보관한다.
- 메뉴 식별값, 단가, 수량 등을 다룰 예정이다.
- 실제 속성은 다음 문서에서 확정한다.

[CartItemControl]
- 장바구니 항목 하나를 화면에 표시한다.
- 수량 증가·감소와 삭제 입력을 받는다.
- 변경 또는 삭제 요청을 이벤트로 알린다.

[ShoppingCartControl]
- CartItemData 목록을 관리할 예정이다.
- 필요한 CartItemControl을 생성하고 배치한다.
- 개별 항목의 이벤트를 받아 처리한다.



# 5. 구현 순서 정리
[예정 순서]
ShoppingCartControl.md 계획 작성

→ CartItemData.md 설계
→ CartItemData 코드 작성

→ CartItemControl.md 설계
→ CartItemControl UI 및 코드 작성

→ ShoppingCartControl UI 및 코드 작성

→ Form1과 연결

→ 각 문서 최종 보완
→ Learning_Notes 정리