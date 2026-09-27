
# 1. 역할
- 여러 UI에서 사용할 수 있는 둥근 Panel을 만든다.
- 둥근 외형이 필요한 UI에서 재사용할 수 있도록 한다.


# 2. 설계 기준
- 기본 Panel을 상속하여
  공통 외형을 제공한다.


# 3. 구현 예정 요소
- BorderWidth: 테두리 두께
- BorderRadius: 테두리 모서리 둥글기
- BorderColor: 테두리 색깔
- Background: 사각형 내부 색깔


# 4. 구현 방향
Panel 상속
↓
외형 설정값 정의
↓
설정값을 이용해
둥근 Panel 구현
↓
여러 UI에서 재사용


# 5. 현재 단계
- 현재는 RoundedPanel의 역할과 구현 방향만 정한다.
- 실제 그리기 방법과 세부 구현 구조는
  RoundedPanel을 구현하면서 구체화한다.