# player1
- ここはある程度形になったらまとめる場所


- ここはOAKに関係ありそうなscriptを入れた作業場
- 20230704_materialがぴんくになっているのを直したら、runtimeserrorが起きている。
- 壊れる前のブランチを作成した。commit全然していなかったからかなり前のデータになる恐れがある。
- ブランチからブランチになぜか移動できなくなったからかなりだるい。解決した20230704
- openpose for unityが動かんからPythonのコードからさくせいするしかないのではないか
- 正直面倒かと、サンプルが見つかれば良いが
- 敵→障害物を発射する
- Player→oakで動かす
- エフェクトや背景を追加してもいいのでは

## memo

Unityでプレイヤーに向かって障害を飛ばす
ものを飛ばす
https://futabazemi.net/notes/unity-enemy_shot3d

敵を見えなくして、ぼす画面から障害物が飛んでくるようにする
OAKのカメラの設置をする、どうにかして自分のUnityで動かせるようにする。
結局OAKどう入れればよい
なんかディスプレイの設定でできそうな気ガスr
追加するエフェクトとか
スコアや体力
当たった判定が欲しい
得点もよけたら点数
当たったらマイナスみたいに
横だけの動きにする
何かキャラクターを４足歩行のオブジェクト
　
destroy： objectを消してくれる関数
Instantiate：objectを元にobjectを生成する関数。（clone)
Quaternion.identity　回転していないQuaternion
velocity　ベクトル速度　vector３
参照：https://tech.pjin.jp/blog/2021/03/31/unity-transform_vector3/

