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

## 0. 경로 계산 메서드를 왜 static으로 구현하는가?
- 객체별로 보관할 상태가 없다.
- 경로 계산에 필요한 값은 모두 매개변수로 전달받는다.
- Rectangle rect + int radius 
  → 경로 계산
  → GraphicsPath 반환
  → 역할 종료

- 계산이 끝난 뒤 rect와 radius를 
 객체 내부 필드에 계속 저장할 필요가 없다.
-  따라서 특정 객체의 상태 없이 입력값으로 계산하고
결과만 반환하는 static 메서드가 적합하다.

[현재 로직과 연결]
- RoundedPanel A → rectA, radiusA 전달
- RoundedPanel B → rectB, radiusB 전달
- RoundedPanel C → rectC, radiusC 전달
- 각 RoundedPanel 
 → GraphicsUtil .GetRoundedRectanglePath(…) 
 → 동일한 경로 계산 로직 사용 
 → 각각의 GraphicsPath 반환

- GraphicsUtil 자체는 
 A, B, C의 Rectangle이나 radius를 계속 저장하지 않는다.


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

## GraphicsPath로 둥근 사각형 경로 계산
[1. 화면 좌표]
- WinForms의 화면 좌표는 왼쪽 위를 기준으로 한다.
 →  X 좌표: 오른쪽으로 갈수록 값이 증가
 →  Y 좌표: 아래쪽으로 갈수록 값이 증가


[2. 둥근 모서리 영역 계산]
- 각 모서리에 Arc를 추가하기 전, Arc가 그려질 영역을 정의한다.
 → radius를 원의 반지름으로 사용한다.
 → radius를 가지는 원이 들어갈 수 있는 크기의 사각형의 형태
 → 이때 사각형의 가로,세로 변의 크기는 지름과 같다.


[3. 네 모서리 영역 정의]
- 구한 diameter를 이용하여 네 모서리의 영역을 계산한다.

- 왼쪽에 위치하는 영역은 rect.X를 기준으로 한다.
- 오른쪽에 위치하는 영역은 rect.Right에서 지름의 크기를 뺀다.
- 위쪽에 위치하는 영역은 rect.Y를 기준으로 한다.
- 아래쪽에 위치하는 영역은 rect.Bottom에서지름의 크기를 뺀다.


[4. 모서리에 Arc 적용하기 전 원의 각도]
                           270°
                           위
                           ↑
                           │
                           │
180°  왼쪽  ←──────●──────→  오른쪽  0°
                           │                   
                           │
                           ↓
                         아래
                          90°

양수 sweepAngle
→ 시작 각도에서 시계 방향

음수 sweepAngle
→ 시작 각도에서 반시계 방향


[5. 모서리에 Arc 적용]
- AddArc(영역, 시작 각도, 그릴 각도) 적용
- 그릴 각도는 양수이면 시계 방향/ 음수이면 반시계 방향이다.
  → 시작 각도에서 Arc를 얼마나 그릴지 정의하는 것이다.


[6. CloseFigure()]
- 네 모서리의 Arc를 모두 추가한 뒤 CloseFigure()를 호출한다.
 → 현재 경로의 마지막 지점과 시작 지점을 연결하여
   닫힌 도형의 경로를 완성한다.


# 6. 현재 단계
1. Rectangle 영역 계산 확정
  → RoundedPanel을 그릴 영역을 Rectangle로 지정했다.
  → BorderWidth를 고려하여 테두리가 잘리지 않도록 실제 그릴 영역을 계산했다.

2. 둥근 사각형 경로 계산 확정
- GraphicsPath를 이용하여  둥근 사각형 경로를 만드는 계산 방식을 정리했다.
  → radius를 기준으로 네 모서리 영역을 계산한다.
  → 각 영역에 AddArc()를 적용하여 네 모서리의 Arc를 추가한다.
  → CloseFigure()를 통해 닫힌 사각형 경로를 완성한다.

3. 다음 구현 단계
- 계산한 GraphicsPath를 이용하여 실제 RoundedPanel을 그린다.
- 사각형 내부에 Background 색상을 채운다.
- BorderWidth와 BorderColor를 이용해둥근 테두리를 그린다.


