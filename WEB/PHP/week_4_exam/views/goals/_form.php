<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

/* @var $this yii\web\View */
/* @var $model app\models\Goals */
/* @var $form yii\widgets\ActiveForm */
?>

<div class="goals-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'player_id')->dropdownList($players) ?>

    <?= $form->field($model, 'player_passed_id')->dropdownList($players) ?>

    <?= $form->field($model, 'match_id')->dropdownList($matches) ?>

    <?= $form->field($model, 'goal_minute')->input('number') ?>

    <?= $model->isDelete = false ?>

    <div class="form-group">
        <?= Html::submitButton('Cохранить', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
