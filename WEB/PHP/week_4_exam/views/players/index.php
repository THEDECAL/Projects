<?php

use yii\helpers\Html;
use yii\grid\GridView;
use yii\helpers\Url;
use app\controllers\SiteController;

$this->title = 'Игроки';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="players-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= (SiteController::checkOnAdmin())?Html::a('Добавить Игрока', ['create'], ['class' => 'btn btn-success']):'' ?>
    </p>
    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            [
                'attribute' => 'photo_filename',
                'value' => function ($model){
                    return Html::img(app\models\Players::PHOTOS_DIR . $model->photo_filename,
                        [
                            'class' => 'player-photo-small player-photo'
                        ]
                    );
                },
                'format' => 'raw',
            ],
            'name',
            [
                'attribute' => 'position_id',
                'value' => function($model){
                    return $model->position->name;
                },
            ],
            [
                'attribute' => 'command_id',
                'value' => function ($model){
                    $id = $model->command_id;
                    $command = app\models\Commands::findOne($id);
                    $emblem = app\models\Commands::findOne($id)->emblem_filename;
                    $image = Html::img(app\models\Commands::EMBLEMS_DIR . $command->emblem_filename, ['height' => '50px']);
                    $text = ' ' . $command->name;
                    return Html::a($image . $text, Url::to(['commands/view', 'id' => $id]));
                },
                'format' => 'raw',
            ],

            [
                'class' => 'yii\grid\ActionColumn',
                'visibleButtons' => [
                    'update' => SiteController::checkOnAdmin(),
                    'delete' => SiteController::checkOnAdmin()
                ]
//                'visible' => SiteController::checkOnAdmin()
            ],
        ],
    ]); ?>

</div>
