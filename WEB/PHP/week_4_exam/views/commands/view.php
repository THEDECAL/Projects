<?php

use yii\widgets\DetailView;
use yii\grid\GridView;
use yii\helpers\Html;
//use yii\helpers\ArrayHelper;
use \yii\web\YiiAsset;
use app\controllers\SiteController;

$this->title = $model->name;
$this->params['breadcrumbs'][] = ['label' => 'Комманды', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
YiiAsset::register($this);
?>
<div class="commands-view">

    <div style='display: flex; flex-direction: row; justify-content: flex-start;'>

        <div style="margin-right: 40px;" >
            <h1><?= Html::encode($this->title) ?></h1>

            <?php if(SiteController::checkOnAdmin()){ ?>
                <p>
                    <?= Html::a('Изменить', ['update', 'id' => $model->id], ['class' => 'btn btn-primary']) ?>
                    <?= Html::a('Удалить', ['delete', 'id' => $model->id], [
                        'class' => 'btn btn-danger',
                        'data' => [
                            'confirm' => 'Are you sure you want to delete this item?',
                            'method' => 'post',
                        ],
                    ]); ?>
                </p>
            <?php } ?>

            <?= DetailView::widget([
                'model' => $model,
                'attributes' => [
                    [
                        'attribute' => 'emblem_filename',
                        'value' => '../views/emblems/' . $model->emblem_filename,
                        'format' => ['image',['width '=> '100','height' => '100']]
                    ],
                    'name',
                    'coach',
                    [
                        'attribute' => 'home_stadium_id',
                        'value' => $model->home_stadium_id = $model->stadium->name . ' (' . $model->stadium->city . ')'
                    ]
                ],
            ]) ?>
        </div>

        <div>
            <h3>Состав на текущий год</h3>

            <?= GridView::widget([
                'dataProvider' => $playersProvider,
                'columns' => [
                    'name',
                    [
                        'attribute' => 'position_id',
                        'value' => function($model){
                            return $model->position->name;
                        },
                        'enableSorting' => false
                    ]
                ],
            ]); ?>
        </div>

    </div>
</div>
