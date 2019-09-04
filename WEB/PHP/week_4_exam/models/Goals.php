<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "goals".
 *
 * @property int $id
 * @property int $player_id
 * @property int $player_passed_id
 * @property int $match_id
 * @property int $goal_minute
 * @property int $isDelete
 *
 * @property Matches $match
 * @property Players $player
 * @property Players $playerPassed
 */
class Goals extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'goals';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['player_id', 'player_passed_id', 'match_id', 'goal_minute'], 'required'],
            [['player_id', 'player_passed_id', 'match_id', 'goal_minute', 'isDelete'], 'integer'],
            [['match_id'], 'exist', 'skipOnError' => true, 'targetClass' => Matches::className(), 'targetAttribute' => ['match_id' => 'id']],
            [['player_id'], 'exist', 'skipOnError' => true, 'targetClass' => Players::className(), 'targetAttribute' => ['player_id' => 'id']],
            [['player_passed_id'], 'exist', 'skipOnError' => true, 'targetClass' => Players::className(), 'targetAttribute' => ['player_passed_id' => 'id']],
            //Проверка на различие игроков
            ['player_id', 'compare', 'compareAttribute' => 'player_passed_id', 'operator' => '!=', 'message' => 'Игрок который забил и передал должны отличатся.'],
            ['player_passed_id', 'compare', 'compareAttribute' => 'player_id', 'operator' => '!=', 'message' => 'Игрок который забил и передал должны отличатся.'],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'player_id' => 'Игрок',
            'player_passed_id' => 'Передача',
            'match_id' => 'Матч',
            'goal_minute' => 'Минута',
            'isDelete' => 'Is Delete',
        ];
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getMatch()
    {
        return $this->hasOne(Matches::className(), ['id' => 'match_id']);
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getPlayer()
    {
        return $this->hasOne(Players::className(), ['id' => 'player_id']);
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getPlayerPassed()
    {
        return $this->hasOne(Players::className(), ['id' => 'player_passed_id']);
    }

    /**
     * {@inheritdoc}
     * @return GoalsQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new GoalsQuery(get_called_class());
    }
}
