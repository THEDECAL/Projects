<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\Goals */

$this->title = 'Создать Гол';
$this->params['breadcrumbs'][] = ['label' => 'Голы', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="goals-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
        'players' => $players,
        'matches' => $matches,
    ]) ?>

</div>
