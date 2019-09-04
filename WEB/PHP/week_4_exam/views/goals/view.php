<?php

use yii\helpers\Html;
use yii\widgets\DetailView;
use app\controllers\SiteController;

/* @var $this yii\web\View */
/* @var $model app\models\Goals */
$this->title = $player->name;
$this->params['breadcrumbs'][] = ['label' => 'Голы', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
\yii\web\YiiAsset::register($this);
?>
<div class="goals-view">

    <h1><?= Html::encode($this->title) ?></h1>

    <?php if(SiteController::checkOnAdmin()){ ?>
        <p>
            <?= Html::a('Изменить', ['update', 'id' => $model->id], ['class' => 'btn btn-primary']) ?>
            <?= Html::a('Удалить', ['delete', 'id' => $model->id], [
                'class' => 'btn btn-danger',
                'data' => [
                    'confirm' => 'Вы уверены, что хотите удалить?',
                    'method' => 'post',
                ],
            ]) ?>
        </p>
    <?php } ?>

    <?= DetailView::widget([
        'model' => $model,
        'attributes' => [
            [
                'attribute' => 'player_id',
                'value' => function() use(&$player){
                    $image = Html::img(app\models\Players::PHOTOS_DIR . $player->photo_filename,
                        [
                            'class' => 'player-photo-small player-photo'
                        ]);
                    return $image . '<br>' . $player->name;
                },
                'format' => 'raw'
            ],
            [
                'attribute' => 'player_passed_id',
                'value' => function() use(&$player_passed){
                    $image = Html::img(app\models\Players::PHOTOS_DIR . $player_passed->photo_filename,
                        [
                            'class' => 'player-photo-small player-photo'
                        ]);
                    return $image . '<br>' . $player_passed->name;
                },
                'format' => 'raw'
            ],
            [
                'attribute' => 'match_id',
                'value' => $match->firstCommand->name . ' - ' . $match->secondCommand->name
                            . '<br>' .' (' . $match->date . ')',
                'format' => 'raw'
            ],
            'goal_minute'
        ],
    ]) ?>

</div>
