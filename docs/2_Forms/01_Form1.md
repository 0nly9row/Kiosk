# 역할
- 각 UserControl을 연결하고, 전체 주문 흐름을 구성한다.
- 하위 컨트롤 사이에서 데이터와 동작을 전달하는 브릿지 역할을 한다.


# 쓰임새
1. MenuBoard와 장바구니 UI 연결

[로직 흐름]
- MenuBoard의 ItemClicked 이벤트를 구독한다.
- 이벤트 핸들러에서 MenuItemData를 전달받는다.
- 전달받은 MenuItemData를 장바구니 UI로 전달한다.

 → Form1은 연결만 담당


[이 연결의 영향]
- 장바구니 UI가 MenuItemData를 전달받는다.
- 장바구니 UI 내부에서 새 메뉴를 추가하거나
- 이미 담긴 메뉴라면 수량을 변경한다.
