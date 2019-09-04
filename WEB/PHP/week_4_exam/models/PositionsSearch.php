<?php

namespace app\models;

//use Yii;
use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\Positions;

class PositionsSearch extends Positions
{

    public function rules()
    {
        return [
            [['id', 'isDelete'], 'integer'],
            [['name'], 'safe'],
        ];
    }

    public function scenarios()
    {
        // bypass scenarios() implementation in the parent class
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = Positions::find()->where('isDelete = FALSE');

        // add conditions that should always apply here

        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            // uncomment the following line if you do not want to return any records when validation fails
            // $query->where('0=1');
            return $dataProvider;
        }

        // grid filtering conditions
        $query->andFilterWhere([
            'id' => $this->id,
            'isDelete' => $this->isDelete,
        ]);

        $query->andFilterWhere(['like', 'name', $this->name]);

        return $dataProvider;
    }
}
