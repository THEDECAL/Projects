<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "penalized_persons".
 *
 * @property int $id
 * @property int $match_id
 * @property int $player_id
 * @property int $cnt_rcard
 * @property int $cnt_ycard
 * @property int $isDelete
 *
 * @property Matches $match
 * @property Players $player
 */
class PenalizedPersons extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'penalized_persons';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['match_id', 'player_id', 'cnt_rcard', 'cnt_ycard'], 'required'],
            [['match_id', 'player_id', 'cnt_rcard', 'cnt_ycard', 'isDelete'], 'integer'],
            [['match_id'], 'exist', 'skipOnError' => true, 'targetClass' => Matches::className(), 'targetAttribute' => ['match_id' => 'id']],
            [['player_id'], 'exist', 'skipOnError' => true, 'targetClass' => Players::className(), 'targetAttribute' => ['player_id' => 'id']],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'match_id' => 'Матч',
            'player_id' => 'Игрок',
            'cnt_rcard' => 'Красных карт',
            'cnt_ycard' => 'Жёлтых карт',
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
     * {@inheritdoc}
     * @return PenalizedPersonsQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new PenalizedPersonsQuery(get_called_class());
    }
}
