<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\PenalizedPersons */

$this->title = 'Добавить Штрафника';
$this->params['breadcrumbs'][] = ['label' => 'Штрафники', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="penalized-persons-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
        'players' => $players,
        'matches' => $matches,
    ]) ?>

</div>
