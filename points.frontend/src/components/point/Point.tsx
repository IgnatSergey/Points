import React from "react";
import { Stage, Layer, Circle } from "react-konva";
import Comment from "../comment/comment";
import {IPoint} from "../../types/types";

interface PointProps {
    point: IPoint,
    onDeletePoint: (pointId:string) => void
}

export const Point: React.FC<PointProps> = (props) => {
  return (
    <div
      className="point-container"
      style={{
        left: `${props.point.positionX}px`,
        top: `${props.point.positionY}px`,
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        transform: `translate(-50%, ${-props.point.radius}px)`,
        position: "absolute",
      }}
    >
      <Stage
        style={{
          borderRadius: "50%",
          boxSizing: "border-box",
          display: "inline-block",
        }}
        width={2 * props.point.radius + 4}
        height={2 * props.point.radius + 4}
      >
        <Layer>
          <Circle
            x={props.point.radius + 2}
            y={props.point.radius + 2}
            radius={props.point.radius}
            fill={`#${props.point.color}`}
            onDblClick={() => {
              console.log("sdfsdf");
              props.onDeletePoint(props.point.id);
            }}
          />
        </Layer>
      </Stage>
      {props.point.comments.map((comment: any) => {
        return <Comment key={comment.id} comment={comment} />;
      })}
    </div>
  );
};
