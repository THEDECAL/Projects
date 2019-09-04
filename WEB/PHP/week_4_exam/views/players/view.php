<?php

use yii\helpers\Html;
use yii\widgets\DetailView;
use \yii\web\YiiAsset;
use app\controllers\SiteController;

$this->title = $model->name;
$this->params['breadcrumbs'][] = ['label' => 'Игроки', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
YiiAsset::register($this);
?>
<div class="players-view">

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
                'attribute' => 'photo_filename',
                'value' => app\models\Players::PHOTOS_DIR . $model->photo_filename,
                'format' => ['image', ['class' => 'player-photo-large player-photo']],
            ],
            'name',
            [
                'attribute' => 'position_id',
                'value' => $model->position->name
            ]
        ],
    ]) ?>
    
</div>
