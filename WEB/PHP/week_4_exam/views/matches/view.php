<?php

use yii\helpers\Html;
use yii\widgets\DetailView;
use app\controllers\SiteController;

/* @var $this yii\web\View */
/* @var $model app\models\Matches */
$this->title = $model->firstCommand->name . ' - ' .
                $model->secondCommand->name;
$this->params['breadcrumbs'][] = ['label' => 'Матчи', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
\yii\web\YiiAsset::register($this);
?>
<div class="matches-view">

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
            'date',
            [
                'attribute' => 'first_command_id',
                'value' => $model->firstCommand->name
            ],
            [
                'attribute' => 'second_command_id',
                'value' => $model->secondCommand->name
            ],
            'score',
        ],
    ]) ?>

</div>
