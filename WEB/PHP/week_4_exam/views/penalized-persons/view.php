<?php

use yii\helpers\Html;
use yii\widgets\DetailView;
use app\controllers\SiteController;

/* @var $this yii\web\View */
/* @var $model app\models\PenalizedPersons */

$this->title = $model->id;
$this->params['breadcrumbs'][] = ['label' => 'Penalized Persons', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
\yii\web\YiiAsset::register($this);
?>
<div class="penalized-persons-view">

    <h1><?= Html::encode($this->title) ?></h1>

    <?php if(SiteController::checkOnAdmin()){ ?>
        <p>
            <?= Html::a('Update', ['update', 'id' => $model->id], ['class' => 'btn btn-primary']) ?>
            <?= Html::a('Delete', ['delete', 'id' => $model->id], [
                'class' => 'btn btn-danger',
                'data' => [
                    'confirm' => 'Are you sure you want to delete this item?',
                    'method' => 'post',
                ],
            ]) ?>
        </p>
    <?php } ?>

    <?= DetailView::widget([
        'model' => $model,
        'attributes' => [
//            'id',
            'match_id',
            'player_id',
            'cnt_rcard',
            'cnt_ycard',
//            'isDelete',
        ],
    ]) ?>

</div>
