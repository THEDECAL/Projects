<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\Matches */
$title = $model->firstCommand->name . ' - ' .
		$model->secondCommand->name;
$this->title = 'Изменить Матч: ' . $title;
$this->params['breadcrumbs'][] = ['label' => 'Матчи', 'url' => ['index']];
$this->params['breadcrumbs'][] = ['label' => $title, 'url' => ['view', 'id' => $model->id]];
$this->params['breadcrumbs'][] = 'Изменить';
?>
<div class="matches-update">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
        'commands' => $commands
    ]) ?>

</div>
