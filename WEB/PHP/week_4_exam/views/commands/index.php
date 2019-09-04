<?php

use yii\helpers\Html;
use yii\grid\GridView;
use app\controllers\SiteController;

/* @var $this yii\web\View */
/* @var $searchModel app\Models\CommandsSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Комманды';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="commands-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <?php if(SiteController::checkOnAdmin()){ ?>
        <p>
                <?= Html::a('Добавить Стадион', ['stadiums/create'], ['class' => 'btn btn-warning']) ?>

                <?= Html::a('Добавить Комманду', ['create'], ['class' => 'btn btn-success']) ?>

                <?= Html::a('Добавить Игрока', ['players/create'], ['class' => 'btn btn-info']) ?>
        </p>
    <?php } ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            [
                'attribute' => 'emblem_filename',
                'value' => function($model){
                    return app\models\Commands::EMBLEMS_DIR . $model->emblem_filename;
                },
                'format' => ['image',['width'=>'40','height'=>'40']],
                'filter' => false,
                'enableSorting' => false,
            ],
            'name',
            'coach',
            [
                'attribute' => 'home_stadium_id',
                'value' => function($model){
                    return $model->stadium->name . ' (' . $model->stadium->city . ')';
                },
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
