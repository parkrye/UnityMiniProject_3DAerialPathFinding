# 3D Aerial Path Finding

비행체의 3D 공중 길찾기 실험 (Unity 미니 프로젝트, 2023).

## 영상

[![시연 영상](https://img.youtube.com/vi/0SppvBGhz-8/hqdefault.jpg)](https://youtu.be/0SppvBGhz-8)

## 방식

- 우선순위 큐(총 예상 거리) 기반 A* 탐색을 3D 좌표에 적용
- 비행체 몸통 크기(반지름)를 고려해 장애물 판정
- 현재 위치에서 목표까지 벽이 없으면 탐색 종료 — 직선으로 날아갈 수 있는 구간은 노드를 줄인다
