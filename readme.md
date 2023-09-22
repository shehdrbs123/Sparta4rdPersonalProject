# 3번째 개인 프로젝트

### 노동균

# 개요

 이번 프로젝트에서는 기존 제출된 프로젝트 + 강의의 내용을 포함한 프로젝트에 과제를 진행하여 기존 코드를 활용해 새로운 코드를 작성하고 적용해보는 것을 목표로 진행하였습니다.

 이를 통해서 기존 코드들의 재 사용, 수정을 통해 현 프로젝트에 맞게 개선하는 과정을 거치면서 앞으로의 이전의 코드, 다른 사람의 코드 등 여러 코드들에 맞게 적응할 수 있는 능력을 기르고 싶었습니다.

# 구조설계

## 과제 2의 세부사항


[Chapter 3-2 Unity 게임개발 숙련 개인과제](https://www.notion.so/Chapter-3-2-Unity-3db6735ddda14d6dad34be754e6b0d3f?pvs=21)
### 진행한 과제 2번 스파르타 던전
## 구현 내용


### 필수 과제 
- 상태창 구현
- 인벤토리 구현

  
### 그 외
- 입력 무시기능 완성
- 공통 UI 설계 및 구현
- CharacterStats 재설계
- ItemManager 설계/구현
- UIManager에 InventoryUI /Status UI 등 관련 UI Prefab 등록;

   
## 클래스 설계(계략적)

![Untitled](Image/Untitled.png)

![Untitled](Image/Untitled%201.png)

## 기능 명세서

[기능/구현 목록](Image/기능%20구현%20목록.csv)

## 구현 내용 세부
- 입력 무시기능 추가
  - BaseUI, UIManager를 활용, InventoryUI, StatusUI등 입력 무시가 필요한 UI에 대해 입력 무시기능 추가
- 공통 UI 설계 및 구현
  - YesOrNoUI, ConfirmUI 등 물음에 답을 필요로 하는 UI를 어디서든 사용할 수 있도록 설계
- CharaterStats 재설계
  - 능력치에 대해서 추가/삭제가 편리하도록 설계하였음.  
- ItemManager 설계/구현
  - Scriptable Object, Prefabs 활용
- UIManager에 InventoryUI, StatusUI, ItemSlotUI
  - UIPrefab 와 ObjectPool을 이용해, Scene에 UI가 없어도 사용가능하게끔 설계
- 이벤트 구독 형식의 UI <-> 데이터 간 데이터 동기화
  

