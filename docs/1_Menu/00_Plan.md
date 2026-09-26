# 목차
0. 문서 목적
1. 메뉴판 역할
2. 설계 기준
3. 만들 순서


# 0. 문서 목적
- 메뉴판에서 무엇을 만들 것인가?
- 각 요소를 어떤 기준으로 나눌 것인가?
- 어떤 순서로 만들 것인가?


# 1. 메뉴판 역할
- 주문 가능한 상품 목록을 사용자에게 보여준다.


# 2. 설계 기준
1. 데이터와 UI 분리 기준
- 메뉴 하나의 데이터: MenuItemData
- 메뉴 하나의 UI: MenuItemControl


2. 상품 하나와 목록 분리
- 상품 하나 UI를 모아 관리하는 목록 UI: MenuBoard


3. UI 변경 책임 분리
- 각 UI는 자신 내부의 컨트롤 및 속성의 변경만 책임진다.
  → MenuBoard는 MenuItemControl를 생성 
  → MenuItemControl는 내부 Label, PictureBox...변경


4. Event를 통한 동작 전달
- 한 UI의 동작이 다른 UI나 Form에 영향을 주면 Event를 통해 알린다.

- Event를 전달받은 쪽에서 필요한 동작을 처리한다.

- 직접적인 동작이 필요한 곳에서 Event Handler를 구현한다.
 

# 3. 만들 순서
1. MenuItemData
2. MenuItemControl
3. MenuBoard
