<?php

namespace app\controllers;

use Yii;
use app\models\Players;
use app\models\Stadiums;
use app\models\Commands;
use app\Models\CommandsSearch;
use yii\web\Controller;
use yii\web\NotFoundHttpException;
use yii\filters\VerbFilter;
use yii\helpers\ArrayHelper;
use yii\data\ActiveDataProvider;
use yii\filters\AccessControl;
use \yii\web\HttpException;


class CommandsController extends Controller
{
    private function getStadiums() :Array{
        $stadiums = Stadiums::find()->all();
        $stadiums = ArrayHelper::map($stadiums, 'id', 'name', 'city');
        array_unshift($stadiums, '');

        return $stadiums;
    }

    public function behaviors()
    {
        return [
            'access' => [
                'class' => AccessControl::className(),
                'denyCallback' => function () {
                    throw new HttpException(403,'Авторизируйтесь, чтобы вносить изменения.');
                    },
                'only' => ['create', 'update', 'delete', 'view', 'index'],
                'rules' => [
                    [
                        'allow' => true,
                        'actions' => ['view', 'index'],
                        'roles' => ['?'],
                    ],
                    [
                        'allow' => true,
                        'actions' => ['view', 'index', 'create', 'update', 'delete'],
                        'roles' => ['@'],
                    ],
                ]
            ],
            'verbs' => [
                'class' => VerbFilter::className(),
                'actions' => [
                    'delete' => ['POST'],
                ],
            ],
        ];
    }

    public function actionIndex()
    {
        $searchModel = new CommandsSearch();
        $dataProvider = $searchModel->search(Yii::$app->request->queryParams);

        return $this->render('index', [
            'searchModel' => $searchModel,
            'dataProvider' => $dataProvider,
        ]);
    }

    public function actionView($id)
    {
        $playersProvider = new ActiveDataProvider([
            'query' =>  Players::find()
            ->where("command_id = $id")
        ]);

        return $this->render('view', [
            'model' => $this->findModel($id),
            'playersProvider' => $playersProvider
        ]);
    }

    public function actionCreate()
    {
        $model = new Commands();

        if ($model->load(Yii::$app->request->post())){
            if ($_FILES and $_FILES['Commands']['error']['emblem_filename'] == 0){
                $tmp_name = $_FILES['Commands']['tmp_name']['emblem_filename'];
                $file_ext = pathinfo($_FILES['Commands']['name']['emblem_filename'], PATHINFO_EXTENSION);
                $filename = uniqid() . '.' . $file_ext;
                rename($tmp_name, Commands::EMBLEMS_DIR . $filename);
                $model->emblem_filename = $filename;
            }
            if($model->save())
                return $this->redirect(['index']);
        }

        return $this->render('create', [
            'model' => $model,
            'stadiums' => $this->getStadiums()
        ]);
    }

    public function actionUpdate($id)
    {
        $model = $this->findModel($id);

        if ($model->load(Yii::$app->request->post())){
            if ($_FILES and $_FILES['Commands']['error']['emblem_filename'] == 0){
                $tmp_name = $_FILES['Commands']['tmp_name']['emblem_filename'];
                $file_ext = pathinfo($_FILES['Commands']['name']['emblem_filename'], PATHINFO_EXTENSION);
                $filename = uniqid() . '.' . $file_ext;
                rename($tmp_name, Commands::EMBLEMS_DIR . $filename);
                $model->emblem_filename = $filename;
            }
            else{
                $model->emblem_filename = Commands::find($id)->one()->emblem_filename;
            }

            $model->save();

            return $this->redirect(['index']);
        }

        return $this->render('update', [
            'model' => $model,
            'stadiums' => $this->getStadiums()
        ]);
    }

    public function actionDelete($id)
    {
        $model = $this->findModel($id);
        $model->isDelete = 1;
        $model->save();

        return $this->redirect(['index']);
    }

    protected function findModel($id)
    {
        if (($model = Commands::findOne($id)) !== null) {
            return $model;
        }

        throw new NotFoundHttpException('The requested page does not exist.');
    }
}
