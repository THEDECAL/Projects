<?php

use yii\helpers\Html;
use yii\grid\GridView;
use app\controllers\SiteController;

/* @var $this yii\web\View */
/* @var $searchModel app\Models\StadiumsSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Стадионы';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="stadiums-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= (SiteController::checkOnAdmin())?Html::a('Добавить Стадион', ['create'], ['class' => 'btn btn-success']):'' ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            // 'id',
            'city',
            'name',
            // 'isDelete',

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
