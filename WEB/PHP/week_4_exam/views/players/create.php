<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\Players */

$this->title = 'Добавить Игрока';
$this->params['breadcrumbs'][] = ['label' => 'Игроки', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="players-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
        'positions' => $positions,
        'commands' => $commands
    ]) ?>

</div>
