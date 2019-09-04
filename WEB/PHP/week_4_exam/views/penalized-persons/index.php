<?php

use yii\helpers\Html;
use yii\grid\GridView;
use app\controllers\SiteController;

/* @var $this yii\web\View */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Штрафники';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="penalized-persons-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= (SiteController::checkOnAdmin())?Html::a('Добавить Штрафника', ['create'], ['class' => 'btn btn-success']):'' ?>
    </p>


    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

//            'match_id',
            [
                'attribute' => 'match_id',
                'value' => function($model){
                    $match = app\models\Matches::findOne($model->match_id);
                    return $match->firstCommand->name . ' - ' . $match->secondCommand->name
                        . ' (' . $match->date . ')';
                },
                'filter' => false,
                'enableSorting' => false

            ],
//            'player_id',
            [
                'attribute' => 'player_id',
                'value' => function($model){
                    return app\models\Players::findOne($model->player_id)->name;
                },
            ],
            'cnt_rcard',
            'cnt_ycard',

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
