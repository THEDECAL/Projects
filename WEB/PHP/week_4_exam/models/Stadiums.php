<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "stadiums".
 *
 * @property int $id
 * @property string $city
 * @property string $name
 * @property int $isDelete
 *
 * @property Commands[] $commands
 */
class Stadiums extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'stadiums';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['city', 'name'], 'required', 'message' => 'Поле должно быть заполнено.'],
            [['isDelete'], 'integer'],
            [['city'], 'string', 'max' => 32],
            [['name'], 'string', 'max' => 64],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'city' => 'Город*',
            'name' => 'Название*',
            'isDelete' => 'Is Delete',
        ];
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getCommands()
    {
        return $this->hasMany(Commands::className(), ['home_stadium_id' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return StadiumsQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new StadiumsQuery(get_called_class());
    }
}
