<?php

use yii\helpers\Html;
use yii\grid\GridView;
use yii\helpers\Url;
use app\controllers\SiteController;

/* @var $this yii\web\View */
/* @var $searchModel app\Models\MatchesSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Матчи';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="matches-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?php
            if(SiteController::checkOnAdmin()) {
                echo Html::a('Добавить Матч', ['create'], ['class' => 'btn btn-success']);
            }
        ?>
    </p>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'columns' => [

            'date',
            [
                'attribute' => 'first_command_id',
                'value' => function ($model) {
                        $id = $model->firstCommand->id;
                        $image = Html::img(app\models\Commands::EMBLEMS_DIR . $model->firstCommand->emblem_filename, ['height' => '50px']);
                        $text = ' ' . $model->firstCommand->name;
                        return Html::a($image, Url::to(['commands/view', 'id' => $id])) . $text;
                },
                'format' => 'raw',
                'filter' => false,
                'enableSorting' => false
            ],
            [
                'attribute' => 'score',
                'value' => function($model){ return '<h3>' . $model->score . '</h3>'; },
                'format' => 'raw',
                'label' => 'Счёт',
                'filter' => false,
                'enableSorting' => false
            ],
            [
                'attribute' => 'second_command_id',
                'value' => function ($model){
                        $id = $model->secondCommand->id;
                        $image = Html::img(app\models\Commands::EMBLEMS_DIR . $model->secondCommand->emblem_filename, ['height' => '50px']);
                        $text = ' ' . $model->secondCommand->name;
                        return Html::a($image, Url::to(['commands/view', 'id' => $id])) . $text;
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
