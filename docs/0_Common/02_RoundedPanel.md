# 1. 역할
- 여러 UI에서 사용할 수 있는 둥근 Panel을 만든다.
- 둥근 외형이 필요한 UI에서 재사용할 수 있도록 한다.


# 2. 설계 기준
- 기본 Panel을 상속하여 공통 외형을 제공한다.


# 3. 구현 요소
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


# 5. 코드를 작성하며 헷갈린 점

## 1. 사각형 크기 및 위치 영역 지정 로직의 의미
[1. Rectangle의 값의 의미는?]
- new Rectangle(위치(x, y)와 크기(가로(width), 세로(height)))
 → x: 왼쪽에서 얼마나 떨어질지에 대한 시작 위치
 → y: 위쪽에서 얼마나 떨어질지에 대한 시작 위치
 → width: 실제 그릴 영역의 가로 길이
 → height: 실제 그릴 영역의 세로 길이


[2. Rectangle의 값들의 설정은?]
- x: _borderWidth
- y: _borderWidth
 → 테두리 두께를 고려하지 않고
    컨트롤의 가장자리부터 바로 그리면 
    테두리 일부가 그리기 영역 밖으로 나갈 수 있다.
 → 따라서 시작 위치를 테두리 두께만큼 안쪽으로 잡는다.

- width: Width - _borderWidth * 2
- height: Height - _borderWidth * 2
 → 가로에서는 왼쪽과 오른쪽, 세로에서는 위쪽과 아래쪽의 테두리 영역을 고려한다.

- 핵심 Rectangle 계산은 아래처럼 이해한다.
  "컨트롤 내부에서 테두리가 잘리지 않도록
  실제로 그릴 영역을 조금 안쪽으로 잡는 것"


[3. 예시]
- 가정
 → 컨트롤 크기
    Width = 300
    Height = 200

 → 테두리 굵기(두께)
    BorderWidth = 2

- 실사용 Rectangle의 "시작위치 (2, 2)/ 전체 크기 (296 × 196)"
 → x = 2
 → y = 2
 → width = 300 - 2 * 2 = 296
 → height = 200 - 2 * 2 = 196


# 6. 현재 단계
1. Rectangle까지 구현
- RoundedPanel을 그릴 영역을 Rectangle로 지정했다.
- 하지만 Rectangle만으로는 둥근 모서리의 경로를 표현할 수 없다.

2. 앞으로 구현해야할 것
- Rectangle영역에 따른 정확한 둥근 모서리의 사각형 경로가 필요하다.
 → GraphicsPath로 정확한 경로를 만들어낸다.

3. 정리
- Rectangle → 어디에 그릴지 영역 결정
- GraphicsPath → 어떤 모양으로 그릴지 결정

