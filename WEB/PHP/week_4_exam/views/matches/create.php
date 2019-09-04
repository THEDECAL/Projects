<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\Matches */

$this->title = 'Добавить Матч';
$this->params['breadcrumbs'][] = ['label' => 'Матчи', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="matches-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
        'commands' => $commands,
    ]) ?>

</div>
