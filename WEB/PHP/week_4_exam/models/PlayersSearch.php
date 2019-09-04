<?php

namespace app\Models;

use yii\base\Model;
use yii\data\ActiveDataProvider;

class PlayersSearch extends Players
{

    public function rules()
    {
        return [
//            [['id', 'isDelete'], 'integer'],
            ['name', 'safe'],
//            [['position_id', 'command_id'], 'integer'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = Players::find()->where('isDelete = FALSE');

        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

//        $query->andFilterWhere([
//            'id' => $this->id,
//            'position_id' => $this->position_id,
//            'command_id' => $this->command_id,
//            'position_id' => Players::find($this->position_id)->one()->name,
//            'positionName' => $this->positionName,
//            'commandName' => $this->commandName,
//            'isDelete' => $this->isDelete,
//        ]);

        $query->andFilterWhere(['like', 'name', $this->name]);
//            ->andFilterWhere(['like', 'position_id', Players::find($this->position_id)->one()->name]);
//            ->andFilterWhere(['like', 'photo_filename', $this->photo_filename]);

        return $dataProvider;
    }
}
