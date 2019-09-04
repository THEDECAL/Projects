<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\Goals */

$match = app\models\Matches::findOne($model->match_id);
$this->title = 'Изменить Гол: ' . $match->firstCommand->name . ' - ' . $match->secondCommand->name
                . ' (' . $model->goal_minute . ' мин.)';
$this->params['breadcrumbs'][] = ['label' => 'Голы', 'url' => ['index']];
$this->params['breadcrumbs'][] = ['label' => $this->title, 'url' => ['view', 'id' => $model->id]];
$this->params['breadcrumbs'][] = 'Изменить';
?>
<div class="goals-update">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
        'players' => $players,
        'matches' => $matches,
    ]) ?>

</div>
