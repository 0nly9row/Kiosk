# 목차
1. 역할
2. 설계 기준
3. UI 구성 계획
4. 데이터 전달 및 표시
5. 이벤트 흐름
6. 다른 구성 요소와의 관계
7. 구현 순서



# 1. 역할
- 장바구니 항목 한 종류를 표시하는 UserControl이다.
- CartItemData의 값을 화면에 반영한다.
- 수량 증가·감소 버튼 입력을 처리한다.
- 자신의 표시 내용을 갱신한다.
- 수량 변경과 삭제 요청을 상위에 알린다.



# 2. 설계 기준
1. 실제 데이터와 화면 표시 분리
- 데이터의 기준은 CartItemData이다.
- UI는 모델에서 값을 읽어 표시한다.

2. 자기 UI만 변경
- 다른 CartItemControl은 직접 수정하지 않는다.

3. 상위 동작은 이벤트로 전달
- 수량 변경 사실을 상위에 알린다.
- 삭제 버튼은 삭제 요청만 알린다.
- 실제 항목 삭제는 ShoppingCartControl이 한다.

4. 계산 책임 유지
- 항목 금액은 CartItemData.SumPrice이다.
- CartItemControl은 결과를 표시만 한다.



# 3. UI 구성 계획
[항목 하나에 필요한 요소]
- 메뉴 이미지: PictureBox
- 메뉴명: Label
- 현재 수량: Label
- 항목 금액: Label
- 수량 감소: Button
- 수량 증가: Button
- 항목 삭제: Button

[항목 금액 표시]
- CartItemData.SumPrice를 표시한다.
- 단가는 별도 Label로 표시하지 않는다.



# 4. 데이터 전달 및 표시
[생성 주체]
- ShoppingCartControl이 동적으로 생성한다.
- 새 메뉴가 담길 때 한 개를 생성한다.
- 이미 담긴 메뉴라면 새로 만들지 않는다.

[데이터 표시 흐름]
ShoppingCartControl
→ CartItemData 생성 또는 조회
→ CartItemControl에 데이터 전달
→ CartItemControl이 값 확인
→ Label과 PictureBox에 표시

[주의점]
- Count가 변해도 Label은 자동으로 바뀌지 않는다.
- 값 변경 후 화면 갱신을 호출해야 한다.



# 5. 이벤트 흐름
1. 수량 관련 이벤트
[CountChanged]
- 항목의 실제 수량이 바뀌었음을 알린다.
- 화면 갱신 후 발생시키는 방향으로 한다.
- ShoppingCartControl이 구독한다.
- 항목의 전체 합계를 직접 전달하지 않는다.

[상황1. 수량 증가]
사용자가 증가 버튼 클릭
→ CartItemControl이 입력 수신
→ CartItemData.Count 증가
→ 현재 Count와 SumPrice 조회
→ CartItemControl 화면 갱신
→ CountChanged 이벤트 발생
→ ShoppingCartControl이 변화 확인

[상황2. 수량 감소]
자가 감소 버튼 클릭
→ 현재 Count 확인
→ 1보다 크면 Count 감소
→ CartItemControl 화면 갱신
→ CountChanged 이벤트 발생

[상황3. 수량이 1인 경우]
- 감소해도 Count를 0으로 만들지 않는다.
- CartItemData의 setter도 1 미만을 거부한다.
- 수량이 그대로라면 변경 이벤트도 내지 않는다.
- 삭제는 별도 삭제 버튼으로 처리한다.

[상황4. 같은 메뉴를 다시 선택한 경우]
ShoppingCartControl에서 기존 항목 검색
→ 기존 CartItemData.Count 증가
→ 해당 CartItemControl 화면 갱신
→ ShoppingCartControl이 전체 값 갱신

- 이 변경은 상위에서 시작한 변경이다.
- 중복 이벤트를 내지 않도록 흐름을 구분한다.


2. 삭제 요청 이벤트
[DeleteClicked]
- 사용자에게 삭제 요청이 발생했음을 알린다.
- ShoppingCartControl이 구독한다.
- 실제 삭제 작업은 상위에서 한다.

[삭제 버튼]
사용자가 삭제 버튼 클릭
→ CartItemControl이 입력 수신
→ DeleteClicked 이벤트 발생
→ ShoppingCartControl이 요청 수신
→ 해당 CartItemData를 목록에서 제거
→ 해당 CartItemControl을 화면에서 제거
→ ShoppingCartControl이 전체 값 갱신




# 6. 다른 구성 요소와의 관계
[MenuItemData]
- 원래 메뉴의 정보를 보관한다.

[MenuBoard]
- 메뉴 선택 시 MenuItemData를 전달한다.

[Form1]
- MenuBoard와 장바구니를 연결한다.

[CartItemData]
- 선택된 메뉴의 정보와 수량을 보관한다.
- SumPrice로 항목 금액을 계산한다.

[CartItemControl]
- 한 항목을 표시하고 버튼 입력을 처리한다.
- 자기 화면을 갱신하고 이벤트를 알린다.

[ShoppingCartControl]
- CartItemData 목록을 관리한다.
- CartItemControl을 생성하고 제거한다.
- 중복 메뉴 확인과 전체 합계 계산을 한다.



# 7. 구현 순서
CartItemControl UI 구성
→ CartItemData 연결
→ 초기 화면 표시
→ 수량 증가·감소 구현
→ 화면 갱신 구현
→ CountChanged 이벤트 연결
→ DeleteClicked 이벤트 연결
→ ShoppingCartControl과 연동
