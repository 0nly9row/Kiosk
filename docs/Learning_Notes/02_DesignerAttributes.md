# 목차
1. 학습 목적 
2. Attribute란?
3. 학습할 Attribute


# 1. 학습 목적
- RoundedPanel에 있는 public 속성은
 코드에서 사용하거나,
 디자이너 속성창에서도 설정한 값을 해당 속성의 setter로 전달할 수 있다. 
- 이때 속성에 Attribute를 붙이면 
 디자이너에서 속성을 알기 쉽게 사용할 수 있다.


# 2. Attribute란?
-  Attribute는 클래스, 속성 등에 부가 정보를 붙이는 방법이다.
-  현재 RoundedPanel에서
  WinForms 디자이너가 해당 속성을 어떻게 보여주고 
  다룰지에 대한 정보를 제공한다.


# 3. 학습할 Attribute
1. DefaultValue 
2. Category 
3. Description


## [1. DefaultValue]
- 해당 속성의 기본값이 무엇인지 알려주는 Attribute이다.
  → 주의. 실제 필드의 값을 초기화하는 코드가 아니다.
  → private int _borderWidth = 3;  // 실제 초기값을 3으로 설정
  → [DefaultValue(3)] // 해당 속성의 기본값이 3이라는 정보를 제공


## [2. Category]
- WinForms 속성 창에서 해당 속성을 어느 그룹에 표시할지 지정한다
- RoundedPanel의 사용자 정의 속성에 동일한 Category를 지정하면
 BorderWidth BorderRadius BorderColor BackGround를 같은 그룹으로 묶어서 확인할 수 있다.
  → 속성의 기능을 변경하지 않음 
  → 속성 창에서 분류하는 역할


## [3. Description]
- 해당 속성이 어떤 역할을 하는지 설명을 제공하는 Attribute이다.
- WinForms 속성 창에서 해당 속성을 선택했을 때,
 속성의 역할을 이해하기 쉽게 설명을 제공할 수 있다.
 → 속성의 동작을 변경하지 않음 
 → 속성의 의미를 설명하는 역할

