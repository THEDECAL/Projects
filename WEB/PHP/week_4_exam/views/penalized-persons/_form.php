<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

/* @var $this yii\web\View */
/* @var $model app\models\PenalizedPersons */
/* @var $form yii\widgets\ActiveForm */
?>

<div class="penalized-persons-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'match_id')->dropdownList($matches) ?>

    <?= $form->field($model, 'player_id')->dropdownList($players) ?>

    <?= $form->field($model, 'cnt_rcard')->input('number') ?>

    <?= $form->field($model, 'cnt_ycard')->input('number') ?>

    <?= $model->isDelete = false ?>

    <div class="form-group">
        <?= Html::submitButton('Сохранить', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
