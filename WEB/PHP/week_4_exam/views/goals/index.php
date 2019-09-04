<?php

use yii\helpers\Html;
use yii\grid\GridView;
use app\controllers\SiteController;

/* @var $this yii\web\View */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Голы';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="goals-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= (SiteController::checkOnAdmin())?Html::a('Добавить Гол', ['create'], ['class' => 'btn btn-success']):'' ?>
    </p>


    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'goal_minute',
            [
                'attribute' => 'player_id',
                'value' => function($model){
                    return $model->player->name;
                },
                'filter' => false,
                'enableSorting' => false
            ],
            [
                'attribute' => 'player_passed_id',
                'value' => function($model){
                    return $model->playerPassed->name;
                },
                'filter' => false,
                'enableSorting' => false
            ],
            [
                'attribute' => 'match_id',
                'value' => function($model){
                    $match = app\models\Matches::find($model->match_id)->one();
                    $fcId = $match->first_command_id;
                    $scId = $match->second_command_id;
                    $fcName = app\models\Commands::findOne($fcId)->name;
                    $scName = app\models\Commands::findOne($scId)->name;

                    return $fcName . ' - ' . $scName . '<br>(' . $match->date . ')';
                },
                'format' => 'raw',
                'filter' => false,
                'enableSorting' => false
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
