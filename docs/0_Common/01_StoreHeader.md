# 역할
- 상점명과 간단한 소개를 표시하는 UserControl이다.


# 구조
- 내부에 Label 두 개를 두어 각각 상점명과 소개를 표시한다.

StoreHeader
↓
상점명 Label
↓
소개 Label


# 값 전달 흐름
상위 UI
↓
StoreHeader Property 설정
↓
Property setter 실행
↓
내부 Label에 값 반영


# 세부 설정
1. 상점명
- 상위에서 설정한 값을 상점명 Label에 표시한다.

2. 상점 소개
- 상위에서 설정한 값을 소개 Label에 표시한다.

- 여러 줄의 소개를 입력할 수 있도록 구성한다.



