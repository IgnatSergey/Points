import React from "react";
import { IComment } from "../../types/types";

interface CommentProps {
  comment: IComment
}

const Comment: React.FC<CommentProps> = (props) => {
  const commentStyle = {
    border: "1px solid #9c9899",
    padding: "3px",
    marginTop: "3px",
    backgroundColor: `#${props.comment.backgroundColor}`,
  };
  return <div style={commentStyle}>{props.comment.text}</div>;
};

export default Comment;
